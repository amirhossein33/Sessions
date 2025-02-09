using System.Collections.Concurrent;

namespace ConcurrentQueue_Test
{
    public class Program
    {
        public static async Task Main()
        {
            Console.WriteLine(" Clinic Appointment System Started...\n");

            var clinic = new ClinicQueue();


            await clinic.AddPatientsAsync();


            await clinic.ProcessPatientsAsync();

            Console.WriteLine("\n All patients have been processed. Clinic is closed.");
        }
    }

    class ClinicQueue
    {
        private ConcurrentQueue<Patient> _patientQueue = new();

        public async Task AddPatientsAsync()
        {
            var tasks = new List<Task>();

            for (int i = 1; i <= 10; i++)
            {
                string patientName = $"Patient {i}";
                tasks.Add(Task.Run(() =>
                {
                    var patient = new Patient(i, patientName);
                    _patientQueue.Enqueue(patient);
                    Console.WriteLine($" {patient.Name} added to queue.");
                }));

                await Task.Delay(100);
            }

            await Task.WhenAll(tasks);
        }

        public async Task ProcessPatientsAsync()
        {
            var doctor1 = Task.Run(() => ProcessPatientsByDoctor(1));
            var doctor2 = Task.Run(() => ProcessPatientsByDoctor(2));

            await Task.WhenAll(doctor1, doctor2);
        }

        private void ProcessPatientsByDoctor(int doctorId)
        {
            while (_patientQueue.TryDequeue(out var patient))
            {
                Console.WriteLine($" Doctor {doctorId} is visiting {patient.Name}...");
                Thread.Sleep(1000);
                patient.IsVisited = true;
                Console.WriteLine($" {patient.Name} has been visited by Doctor {doctorId}.");
            }
        }
    }

    internal class Patient
    {
        public int Id { get; }
        public string Name { get; }
        public bool IsVisited { get; set; } = false;

        public Patient(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}