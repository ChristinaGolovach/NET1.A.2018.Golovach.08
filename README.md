# NET1.A.2018.Golovach.08

# Задание 

- (долг, deadline - 27.10.2018, 15.00) Реализовать метод "пузырьковой" сортировки непрямоугольного ("jagged" array) 
целочисленного массива (не использовать методы класса System.Array!) таким образом, чтобы была возможность, в частности, 
упорядочить строки матрицы:

  в порядке возрастания(убывания) сумм элементов строк матрицы;
  в порядке возрастания(убывания) максимальных элементов строк матрицы;
  в порядке возрастания(убывания) минимальных элементов строк матрицы. Разработать unit-тесты (NUnit фреймворк).
  [Решение](https://github.com/ChristinaGolovach/NET1.A.2018.Golovach.07)

- (долг, deadline - 27.10.2018, 15.00) Разработать неизменяемый класс Polynomial (полином) для работы с многочленами степени от одной переменной вещественного типа (в качестве внутренней структуры для хранения коэффициентов использовать sz-массив). Для разработанного класса переопределить виртуальные методы класса Object; перегрузить операции, допустимые для работы с многочленами (исключая деление многочлена на многочлен), включая "==" и "!=". Реализовать интерфейсы - ICloneable, IEquatable<Polynomial>. Разработать unit-тесты (NUnit фреймворк).
[Решение](https://github.com/ChristinaGolovach/NET1.A.2018.Golovach.05) 
  

- проект сырой: нет комментариев, не везде есть валидация,не везде законченная логика, нет реализации интерфейсов IEiequatable, IComparer.
- (deadline - 31.10.2018, 24.00) Разработать систему типов для описания работы с банковским счетом. Состояние счета определяется его номером, данными о владельце счета (имя, фамилия, e-mail и т.д.), суммой на счете и некоторыми бонусными баллами, которые увеличиваются/уменьшаются каждый раз при пополнении счета/списании со счета на величины различные для пополнения и списания и рассчитываемые в зависимости от некоторых значений величин «стоимости» баланса и «стоимости» пополнения. Величины «стоимости» баланса и «стоимости» пополнения являются целочисленными значениями и зависят от градации счета, который может быть, например, Base, Silver, Gold, Platinum. Для работы со счетом реализовать следующие возможности:

выполнить пополнение на счет;
выполнить списание со счета;
создать новый счет;
закрыть счет.
Протестировать работу с системой типов в консольном приложении.
