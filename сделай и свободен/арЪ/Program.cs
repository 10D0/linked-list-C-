/*(◕‿◕)*/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Collections;
using System.Reflection;
namespace Сделай_И_Свободен
{
    class Student
    {
        private int Index;//номер по порядку - для простого контроля изменений
        private string Name;//Фамилия Имя Отчество
        private float Mark;// Средний балл
        private string Group;// Номер группы
        private Student Next;// ссылка на следующий элемент 
        private Student Origin;  // ДОП ЗАДАНИЕ: ССЫЛКА У КАЖДОГО УЗЛА НА НАЧАЛО СПИСКА
        private Student(int index, string name, float mark, string group) //конструктор
        {
            Index = index;
            Name = name;
            Mark = mark;
            Group = group;
        }
        public class StudentList
        {
            public Student Head;
            public int index_9 = 0;
            public void AddStudent(string name_9, float mark_9, string group_9)// добавление студента
            {
                if (Head == null)                                           //если 
                    Head = new Student(index_9, name_9, mark_9, group_9);
                else
                {
                    Student current = Head;
                    while (current.Next != null)
                        current = current.Next;
                    Student student = new Student(index_9, name_9, mark_9, group_9);// создание и внесение человека на последнее место
                    student.Origin = Head;                                          // каждому студенту добавляется ссылка на первый главный хэд элемент
                    current.Next = student;
                }
                index_9 += 1;
            }
            public void Num()
            {
                Student current_9 = Head;
                index_9 = 0;
                while (current_9 != null)
                {
                    current_9.Index = index_9;
                    index_9 += 1;
                    current_9 = current_9.Next;
                }
            }//перебор всего списка с изменением номеров по порядку
            public void DeleteStudent(int BeenDestroyedOneStudent_9)// удаление студента
            {
                Student previousOne_9 = null, current_9 = Head;
                while (current_9 != null)
                {
                    if (current_9.Index == BeenDestroyedOneStudent_9)// можно добавить другие условия для удаление типо промежутка 
                        if (previousOne_9 == null)      //если нынешний первый
                            current_9 = current_9.Next; //то первым становится второй
                        else                            //иначе
                            previousOne_9.Next = current_9.Next;//ссылка предыдущего указывает на следующего(через нынешнего(на него никто не указывает))
                    else
                        previousOne_9 = current_9;//если не удаляемый обьект то предыдущий это нынешний
                    current_9 = current_9.Next;//нынешний становится следующим
                }
            }
            public void OutStudent(int ChoseOfOutput_9, string NameOrGroup_9, float mark_9, StreamWriter txt)//вывод списка студентов + вывод отобрынных элементов(поиск)
            {
                Student current_9 = Head.Next;
                int Line_9 = 0;
                while (current_9 != null)
                {
                    for (int i = 0; i <= 55; i++)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                        Console.Write(" ");
                        Console.SetCursorPosition(i, Console.CursorTop);
                    }
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.SetCursorPosition(0, Console.CursorTop);
                    switch (ChoseOfOutput_9)
                    {
                        case 1:             // поиск по ФИО
                            if (current_9.Name.Contains(NameOrGroup_9) == true)
                            {
                                for (int i = 0; i <= 55; i++)
                                {
                                    Console.BackgroundColor = ConsoleColor.DarkGray;
                                    Console.Write(" ");
                                    Console.SetCursorPosition(60 + i, 11 + Line_9);
                                }
                                Console.SetCursorPosition(60, 11 + Line_9);
                                Console.Write($"{current_9.Index} ");
                                Console.SetCursorPosition(63, 11 + Line_9);
                                Console.Write($"{current_9.Name}");
                                Console.SetCursorPosition(102, 11 + Line_9);
                                Console.Write($"{current_9.Mark}");
                                Console.SetCursorPosition(110, 11 + Line_9);
                                Console.Write($"{current_9.Group}");
                                Line_9++;
                                Console.SetCursorPosition(1, 0);
                                OutStudent(0, "", 0, null);
                            }
                            break;
                        case 2:             // поиск по ОЦЕНКЕ
                            if (current_9.Mark == mark_9)
                            {
                                for (int i = 0; i <= 55; i++)
                                {
                                    Console.BackgroundColor = ConsoleColor.DarkGray;
                                    Console.Write(" ");
                                    Console.SetCursorPosition(60 + i, 11 + Line_9);
                                }
                                Console.SetCursorPosition(60, 11 + Line_9);
                                Console.Write($"{current_9.Index} ");
                                Console.SetCursorPosition(63, 11 + Line_9);
                                Console.Write($"{current_9.Name}");
                                Console.SetCursorPosition(102, 11 + Line_9);
                                Console.Write($"{current_9.Mark}");
                                Console.SetCursorPosition(110, 11 + Line_9);
                                Console.Write($"{current_9.Group}");
                                Line_9++;
                                Console.SetCursorPosition(1, 0);
                                OutStudent(0, "", 0, null);
                            }
                            break;
                        case 3:             // поиск по ГРУППЕ
                            if (current_9.Group.Contains(NameOrGroup_9) == true)
                            {
                                for (int i = 0; i <= 55; i++)
                                {
                                    Console.BackgroundColor = ConsoleColor.DarkGray;
                                    Console.Write(" ");
                                    Console.SetCursorPosition(60 + i, 11 + Line_9);
                                }
                                Console.SetCursorPosition(60, 11 + Line_9);
                                Console.Write($"{current_9.Index} ");
                                Console.SetCursorPosition(63, 11 + Line_9);
                                Console.Write($"{current_9.Name}");
                                Console.SetCursorPosition(102, 11 + Line_9);
                                Console.Write($"{current_9.Mark}");
                                Console.SetCursorPosition(110, 11 + Line_9);
                                Console.Write($"{current_9.Group}");
                                Line_9++;
                                Console.SetCursorPosition(1, 0);
                                OutStudent(0, "", 0, null);
                            }
                            break;
                        case 4:
                            txt.Write($"{current_9.Name}  ");
                            txt.Write($"{current_9.Mark}  ");
                            txt.WriteLine($"{current_9.Group}");
                            break;
                        default:
                            Console.Write($"{current_9.Index} ");
                            Console.SetCursorPosition(3, Console.CursorTop);
                            Console.Write($"{current_9.Name}");
                            Console.SetCursorPosition(42, Console.CursorTop);
                            Console.Write($"{current_9.Mark}");
                            Console.SetCursorPosition(50, Console.CursorTop);
                            Console.WriteLine($"{current_9.Group}");
                            //показ ориджин элемента
                            //Console.SetCursorPosition(3, Console.CursorTop);
                            //Console.Write($"{current_9.Origin.Index} ");
                            //Console.SetCursorPosition(3, Console.CursorTop);
                            //Console.Write($"{current_9.Origin.Name}");
                            //Console.SetCursorPosition(42, Console.CursorTop);
                            //Console.Write($"{current_9.Origin.Mark}");
                            //Console.SetCursorPosition(50, Console.CursorTop);
                            //Console.WriteLine($"{current_9.Origin.Group}");
                            //Console.SetCursorPosition(3, Console.CursorTop);
                            break;
                    }
                    current_9 = current_9.Next;
                }
                Console.ResetColor();
                Console.WriteLine("                                                       ");
            }
            public void Sorting(Student Head, Student Tail, int ChoseOfKindOfSorting_9)//сортир.
            {
                Student previous = Head;
                switch (ChoseOfKindOfSorting_9)
                {
                    case 1:     //соритровка по алфавиту от А до Я
                        //for (int i = 0; i <= Tail.Index + 1; i++)
                        //{
                        //    Student current = Head;
                        //    while (current.Next != null)
                        //    {
                        //        if (String.Compare(current.Name, current.Next.Name) > 0)
                        //            SwapStudent(previous);
                        //        previous = current;
                        //        if (current.Next != null)
                        //            current = current.Next;
                        //    }
                        //}
                        //break;
                    case 2:     //соритровка по алфавиту от Я до А
                        //for (int i = 0; i <= Tail.Index + 1; i++)
                        //{
                        //    Student current = Head;
                        //    while (current.Next != null)
                        //    {
                        //        if (String.Compare(current.Name, current.Next.Name) < 0)
                        //            //SwapStudent(previous);
                        //        previous = current;
                        //        if (current.Next != null)
                        //            current = current.Next;
                        //    }
                        //}
                        //break;
                    case 3:     //соритровка по оценке от МЕНЬШЕЙ к БОЛЬШЕЙ
                        Student current =Head;
                        Student SndSwap = Head;
                        Student swaper=Head;
                        while (current.Index != Tail.Index)
                        {
                            SndSwap = current;
                            while (SndSwap.Index != Tail.Index)
                            {
                                if (current.Mark > SndSwap.Mark)
                                    swaper = SndSwap;
                                SndSwap = SndSwap.Next;
                            }
                            Swap(current, swaper);
                            current = current.Next;
                        }
                        break;
                    case 4:     //соритровка по оценке от БОЛЬШЕЙ к МЕНЬШЕЙ
                        //for (int i = 0; i <= Tail.Index + 1; i++)
                        //{
                        //    Student current = Head;
                        //    while (current.Next != null)
                        //    {
                        //        if (current.Mark < current.Next.Mark)
                        //            SwapStudent(previous);
                        //        previous = current;
                        //        if (current.Next != null)
                        //            current = current.Next;
                        //    }
                        //}
                        //break;
                    case 5:     //соритровка по группе от МЕНЬШЕЙ к БОЛЬШЕЙ
                        //for (int i = 0; i <= Tail.Index + 1; i++)
                        //{
                        //    Student current = Head;
                        //    while (current.Next != null)
                        //    {
                        //        if (String.Compare(current.Group, current.Next.Group) > 0)
                        //            SwapStudent(previous);
                        //        previous = current;
                        //        if (current.Next != null)
                        //            current = current.Next;
                        //    }
                        //}
                        //break;
                    case 6:    //соритровка по группе от БОЛЬШЕЙ к МЕНЬШЕЙ
                        //for (int i = 0; i <= Tail.Index + 1; i++)
                        //{
                        //    Student current = Head;
                        //    while (current.Next != null)
                        //    {
                        //        if (String.Compare(current.Group, current.Next.Group) < 0)
                        //            SwapStudent(previous);
                        //        previous = current;
                        //        if (current.Next != null)
                        //            current = current.Next;
                        //    }
                        //}
                        break;
                }
            }
            public Student LastStudent()
            {
                Student Tail = Head;
                while (Tail.Next != null)
                    Tail = Tail.Next; //N - становится последним элементом
                for (int i = 0; i < Tail.Index + 5; i++)
                {
                    Console.SetCursorPosition(60, 11 + i); Console.Write($"                                                       ");
                }
                return Tail;
            }
            public int TheHighestIndext()
            {
                Student high = Head;
                int num = Head.Index;
                while (high.Next != null)
                {
                    if (high.Index > high.Next.Index)
                        high.Index = high.Next.Index;
                    high = high.Next;
                }
                return high.Index;
            }
            public Student Swap(Student Current, Student CurrentNext)
            {
                Student Previous, Previous2, next1, next2;
                Previous = Head;
                Previous2 = Head;
                if (Previous == Current)
                    Previous = null;
                else
                    while (Previous.Next != Current) // поиск узла предшествующего currnet
                        Previous = Previous.Next;
                if (Previous2 == CurrentNext)
                    Previous2 = null;
                else
                    while (Previous2.Next != CurrentNext) // поиск узла предшествующего currentnext
                        Previous2 = Previous2.Next;
                next1 = Current.Next;  // узел следующий за current
                next2 = CurrentNext.Next;  // узел следующий за currentnext
                if (CurrentNext == next1)
                {                       // обмениваются соседние узлы
                    CurrentNext.Next = Current;
                    Current.Next = next2;
                    if (Current != Head)
                        Previous.Next = CurrentNext;
                }
                else
                  if (Current == next2)
                {
                    // обмениваются соседние узлы
                    Current.Next = CurrentNext;
                    CurrentNext.Next = next1;
                    if (CurrentNext != Head)
                        Previous2.Next = CurrentNext;
                }
                else
                {
                    // обмениваются несоседние узлы
                    if (Current != Head)
                        Previous.Next = CurrentNext;
                    CurrentNext.Next = next1;
                    if (CurrentNext != Head)
                        Previous2.Next = Current;
                    Current.Next = next2;
                }
                if (Current == Head)
                    return (CurrentNext);
                if (CurrentNext == Head)
                    return (Current);
                return (Head);
            }
        }
       
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(115, 62);
            string[] lines_9 = File.ReadAllLines(@"E:\2 курс\2 семестр\оап\сделай и свободен\список.txt");// создание строчного массива из строк txt файла
            string[] stringSeparators = new string[] { "  " };// разделитель по двойным пробелам чтобы можно было фио нормально вывести
            Student.StudentList List = new Student.StudentList();
            string text;
            float v = -1; //int a; int mark;
            string NameOrGroup;
            //List.AddStudent("",0,"");
            List.AddStudent(lines_9[0].Split(stringSeparators, StringSplitOptions.None)[0], float.Parse(lines_9[0].Split(stringSeparators, StringSplitOptions.None)[1]), lines_9[0].Split(stringSeparators, StringSplitOptions.None)[2]);
            for (int i = 0; i < lines_9.Length; i++)
            {
                string OneLine = lines_9[i];// выбор строки
                string[] FormFields = OneLine.Split(stringSeparators, StringSplitOptions.None);// разделяется по двум пробелам
                List.AddStudent(FormFields[0], float.Parse(FormFields[1]), FormFields[2]);
            }
            Student Tail = List.Head;
            List.OutStudent(0, "", 0, null);
        MainCase://переход на новую попытку
            Console.SetCursorPosition(60, 1); Console.WriteLine($"Введите желаемое действие:            ");
            Console.SetCursorPosition(60, 2); Console.WriteLine($"1 - Сортировка...                     ");
            Console.SetCursorPosition(60, 3); Console.WriteLine($"2 - Поиск...                          ");
            Console.SetCursorPosition(60, 4); Console.WriteLine($"3 - изменение списка...               ");
            Console.SetCursorPosition(60, 5); Console.WriteLine($"4 - сохранение данных                 ");
            Console.SetCursorPosition(60, 6); Console.WriteLine($"5 - сохранение данных в новом файле   ");
            Console.SetCursorPosition(60, 7); Console.WriteLine($"0 - закончить программу               ");
            Console.SetCursorPosition(60, 8); Console.Write($"действие:                                 ");
            Tail = List.LastStudent();
            int number = List.TheHighestIndext();
            for (int i = 0; i < number + 5; i++)
            {
                Console.SetCursorPosition(60, 9 + i); Console.Write($"                                                            ");
            }
            Console.SetCursorPosition(70, 8); v = float.Parse(Console.ReadLine());
            switch (v)
            {
                case 0:
                    goto end;
                case 1:     //Сортировка
                MainCase1:
                    Console.SetCursorPosition(60, 1); Console.WriteLine($"Выберите сортировку:                  ");
                    Console.SetCursorPosition(60, 2); Console.WriteLine($"1 - ФИО по алфавиту                   ");
                    Console.SetCursorPosition(60, 3); Console.WriteLine($"2 - ФИО в обратном алфавитном порядке ");
                    Console.SetCursorPosition(60, 4); Console.WriteLine($"3 - по возрастанию среднего балла     ");
                    Console.SetCursorPosition(60, 5); Console.WriteLine($"4 - по убыванию среднего балла        ");
                    Console.SetCursorPosition(60, 6); Console.WriteLine($"5 - по возрастанию номера группы      ");
                    Console.SetCursorPosition(60, 7); Console.WriteLine($"6 - по убыванию номера группы         ");
                    Console.SetCursorPosition(60, 8); Console.WriteLine($"7 - назад                             ");
                    Console.SetCursorPosition(60, 9); Console.WriteLine($"0 - закончить программу               ");
                    Console.SetCursorPosition(60, 10); Console.Write($"действие:                                ");
                    for (int i = 0; i < number + 5; i++)
                    {
                        Console.SetCursorPosition(60, 11 + i); Console.Write($"                                                       ");
                    }
                    Console.SetCursorPosition(70, 10); v = float.Parse(Console.ReadLine());
                    switch (v)
                    {
                        case 0:
                            goto end;
                        case 1:
                            Console.SetCursorPosition(1, 0);
                            List.Sorting(List.Head, Tail, 1);
                            List.OutStudent(0, "", 0, null);
                            goto MainCase1;
                        case 2:
                            Console.SetCursorPosition(1, 0);
                            List.Sorting(List.Head, Tail, 2);
                            List.OutStudent(0, "", 0, null);
                            goto MainCase1;
                        case 3:
                            Console.SetCursorPosition(1, 0);
                            List.Sorting(List.Head, Tail, 3);
                            List.OutStudent(0, "", 0, null);
                            goto MainCase1;
                        case 4:
                            Console.SetCursorPosition(1, 0);
                            List.Sorting(List.Head, Tail, 4);
                            List.OutStudent(0, "", 0, null);
                            goto MainCase1;
                        case 5:
                            Console.SetCursorPosition(1, 0);
                            List.Sorting(List.Head, Tail, 5);
                            List.OutStudent(0, "", 0, null);
                            goto MainCase1;
                        case 6:
                            Console.SetCursorPosition(1, 0);
                            List.Sorting(List.Head, Tail, 6);
                            List.OutStudent(0, "", 0, null);
                            goto MainCase1;
                        case 7:
                            goto MainCase;
                        default:
                            goto MainCase1;
                    }
                case 2:      //Поиск
                MainCase2:
                    for (int i = 0; i < number + 5; i++)
                    {
                        Console.SetCursorPosition(60, 8 + i); Console.Write($"                                                       ");
                    }
                    Console.SetCursorPosition(60, 1); Console.WriteLine($"Выберите как искать:                  ");
                    Console.SetCursorPosition(60, 2); Console.WriteLine($"1 - по ФИО                            ");
                    Console.SetCursorPosition(60, 3); Console.WriteLine($"2 - по оценке                         ");
                    Console.SetCursorPosition(60, 4); Console.WriteLine($"3 - по группе                         ");
                    Console.SetCursorPosition(60, 5); Console.WriteLine($"4 - назад                             ");
                    Console.SetCursorPosition(60, 6); Console.WriteLine($"0 - закончить программу               ");
                    Console.SetCursorPosition(60, 7); Console.Write($"действие:                                 ");
                    Console.SetCursorPosition(70, 7); v = float.Parse(Console.ReadLine());
                    switch (v)
                    {
                        case 0:
                            goto end;
                        case 1:
                            Console.SetCursorPosition(60, 8); Console.Write($"Введите ФИО для отбора студентов: ");
                            Console.SetCursorPosition(94, 8); NameOrGroup = Console.ReadLine();
                            Console.SetCursorPosition(60, 10);
                            Console.WriteLine("Искомый студенты/искомые студенты: ");
                            Console.SetCursorPosition(60, 11);
                            List.OutStudent(1, NameOrGroup, 0, null);
                            Console.ReadLine();
                            goto MainCase2;
                        case 2:
                            Console.SetCursorPosition(60, 8); Console.Write($"Введите средний балл для отбора студентов: ");
                            Console.SetCursorPosition(103, 8); v = float.Parse(Console.ReadLine());
                            Console.SetCursorPosition(60, 10);
                            Console.WriteLine("Искомый студенты/искомые студенты: ");
                            Console.SetCursorPosition(60, 11);
                            List.OutStudent(2, "", v, null);
                            Console.ReadLine();
                            goto MainCase2;
                        case 3:
                            Console.SetCursorPosition(60, 8); Console.Write($"Введите номер группы для отбора студентов: ");
                            Console.SetCursorPosition(104, 8); NameOrGroup = Console.ReadLine();
                            Console.SetCursorPosition(60, 10);
                            Console.WriteLine("Искомый студенты/искомые студенты: ");
                            Console.SetCursorPosition(60, 11);
                            List.OutStudent(3, NameOrGroup, 0, null);
                            Console.ReadLine();
                            goto MainCase2;
                        case 4:
                            goto MainCase;
                        default:
                            Console.Write("");
                            goto MainCase2;
                    }
                case 3:      //Изменение списка
                MainCase3:
                    Console.SetCursorPosition(60, 1); Console.WriteLine($"Выберите как изменять:                                  ");
                    Console.SetCursorPosition(60, 2); Console.WriteLine($"1 - добавление нового студента                          ");
                    Console.SetCursorPosition(60, 3); Console.WriteLine($"2 - удаление студента                                   ");
                    Console.SetCursorPosition(60, 4); Console.WriteLine($"3 - изменение индексов                                  ");
                    Console.SetCursorPosition(60, 5); Console.WriteLine($"4 - назад                                               ");
                    Console.SetCursorPosition(60, 6); Console.WriteLine($"0 - закончить программу                                 ");
                    Console.SetCursorPosition(60, 7); Console.Write($"действие:                                                   ");
                    for (int i = 0; i < number + 5; i++)
                    {
                        Console.SetCursorPosition(60, 8 + i); Console.Write($"                                                       ");
                    }
                    Console.SetCursorPosition(70, 7); v = int.Parse(Console.ReadLine());
                    switch (v)
                    {
                        case 0:
                            goto end;
                        case 1:      //добавление студента
                            Console.SetCursorPosition(60, 9); Console.WriteLine("Введите данные студента");
                            Console.SetCursorPosition(60, 10); Console.Write("ФИО: "); NameOrGroup = Console.ReadLine();
                            Console.SetCursorPosition(60, 11); Console.Write("Средний балл: "); v = float.Parse(Console.ReadLine());
                            Console.SetCursorPosition(60, 12); Console.Write("Группа: "); text = Console.ReadLine();
                            List.AddStudent(NameOrGroup, v, text); Console.WriteLine("");
                            Console.SetCursorPosition(1, 0);
                            List.OutStudent(0, "", 0, null);
                            goto MainCase3;
                        case 2:      //удаление студента
                            Console.SetCursorPosition(60, 9); Console.Write("Введите индекс уничтожаемого студента:"); v = float.Parse(Console.ReadLine());
                            List.DeleteStudent(Convert.ToInt32(v));
                            Console.SetCursorPosition(1, 0);
                            List.OutStudent(0, "", 0, null);
                            goto MainCase3;
                        case 3:     //перераспределение индексов
                            List.Num();
                            Console.SetCursorPosition(1, 0); List.OutStudent(0, "", 0, null);
                            goto MainCase3;
                        case 4:
                            goto MainCase;
                        default:
                            goto MainC՛�x ��h/p� N·��)��ej_}�� *�ߊ>�"�P���Ou�<���:��RN/��I���-��Ha�E���Ia�G�����]��s�*��`��Ԏ�$�Bю�f��t8;��f[W�s�(��L.���]�+���"r�O����1���2ڮ���W��'��X��r�-e�^`�C��:�H_�q�)���<;��<_��;��#S��~���dZp�"�Ϸ��ŷ��M����y�yr-u�>e�R�ndX��hGr�)n�e/_c�K��5��j�
<�1{��_���:�(J�+��<�~6��o�asE)��B1��$����6Ҷ�k�y�}.��$Z����̗�p� �
�<C�
=l�h#s�*���Qf�UQ��	@4��	��n���Yt�:��Iw�3�����<Í�,>�zEB��N-���a�D�\��c�I��ǻ��e[]��Ӡ��s�:%����sp*�FV ��8��o;b�LY����Rd�Yi��0/���A���0�.��P,��Ju�=��%Gݒ�f�n�W��#b�O���ũ��H;���Y���lh1�(��-f�dY]�����S��)~�9�[4�9۔�z�=G��/o�bKN����z�/@�M��Id�Y�բ�����-x�eb_M����CU��=��(n�d!Z�ߓ�h�r:?��eO��Lɫ����|�
�>�T�H�]��߭���j�~�i|v	47����T��G�`A	�6�x��iuJ>��"�N����j�|!
�?��lk;z�_Kͣ���S`�Aq�'�t�5U���0�f�W��h#Bˏ�!��V��`7C���4���wf1W���"��p�"��W������Z��)a�F9��t�{�cRH�9o�a�E�wN1�%��'�Ж�uO=���+���t$:ٞ�F��3{��P2�J�i�u�=�B*N���!���c^Hĳ��A��uJ=���(����+
�=^��+��Z�R��#TH���q�%��w�7���՛�X ��h/p� N·��-��ej}�� .���>�"�P���Ou�<���:�rN/���I���-��Ha�E���Ha�G���e�]��s�(�� &��$�B՞�&��t8;��gYW���(��D.���],�+���"b�O����1���rڮ���W��'d�X��r�-e�^`�S��:�H�s�)�u�<;��>_��;��#S�