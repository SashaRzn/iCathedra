using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iCathedra
{
    /// <summary>
    /// Семестры
    /// </summary>
    public enum Semestr
    {
        Осенний = 1,
        Весенний = 2
    }

    /// <summary>
    /// Тип нагрузки
    /// </summary>
    public enum WorkloadType
    {
        Фактическая = 0x0001,
        Формальная = 0x0002,
        Фактическая_и_формальная = 0x0003
    }

    [Flags]
    public enum WorkloadHourType
    {
        None = 0,
        Лекции = 1,
        Консультации = 2,
        Зачет = 4,
        Экзамен = 8,
        Индивидуальные_занятия = 16,
        Упражнения = 32,
        Лабораторные = 64,
        Контрольная_работа = 128,
        Курсовая_работа = 256,
        Курсовой_проект = 512,
        Прочее = 1024, 

        Все_виды = Лекции | Консультации | Зачет | Экзамен | Индивидуальные_занятия | Упражнения | Лабораторные |
            Контрольная_работа | Курсовая_работа | Курсовой_проект | Прочее
    }

    /// <summary>
    /// Тип разбиения нагрузки
    /// </summary>
    public enum WorkloadMoveType
    {
        Переносится,
        Копируется
    }
}
