using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Carlibrary
{
    public class Class1
    {
        public enum EngineState { engineAlive, engineDead }
        // Абстрактный базовый класс в иерархии.
        public abstract class Car
        {
            public string PetName { get; set; }
            public int CurrentSpeed { get; set; }
            public int MaxSpeed { get; set; }
            protected EngineState egnState = EngineState.engineAlive;
            public EngineState EngineState
            {
                get { return egnState; }
            }
            public abstract void TurboBoost();
            public Car() { } //конструктор по умолчанию
            public Car(string name, int maxSp, int currSp)  // конструктор с параметрами
            {
                PetName = name;
                MaxSpeed = maxSp;
                CurrentSpeed = currSp;
            }

        }
        // Перечисление для музыкальных носителей
        public enum MusicMedia
        {
            musicCd,    // 0
            musicTape,  // 1
            musicRadio, // 2
            musicMp3    // 3
        }

        // Метод для включения радио
        public void TurnOnRadio(bool musicOn, MusicMedia mm)
        {
            if (musicOn)
                MessageBox.Show(string.Format("Jamming {0}", mm));
            else
                MessageBox.Show("Quiet time...");
        }
        static void InvokeMethodWithArgsUsingLateBinding(Assembly asm)
        {
            try
            {
                // Сначала получим метаданные для типа SportsCar.
                Type sport = asm.GetType("CarLibrary.SportsCar");

                // Затем создадим экземпляр типа SportsCar динамически.
                object obj = Activator.CreateInstance(sport);

                // Вызов метода TurnOnRadio() с аргументами.
                MethodInfo mi = sport.GetMethod("TurnOnRadio");

                // Используем базовые числовые значения перечисления для указания медиаплеера "радио".
                mi.Invoke(obj, new object[] { true, (MusicMedia)2 });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
    }
