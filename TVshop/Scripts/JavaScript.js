<html>
<head>
<title>Реализация календаря</title>
<META http-equiv=Content-Type content="text/html; charset=windows-1251">


<script language="JavaScript">
<!--
// Copyright (c) 2002 Yura Ladik http://www.javaportal.ru All rights reserved.
// Permission given to use the script provided that this notice remains as is.


//Функция возвращает текущее время в виде строки
function getTime()
{
 //Инициализируем переменные с параметрами текущего времени
 var now = new Date()
 var hour = now.getHours()
 var minute = now.getMinutes()
 now = null
 var ampm = "" 
 //Устанавливаем значение часа и am pm
 if (hour >= 12)
 {
  hour -= 12
  ampm = "PM"
 }
 else ampm = "AM"
 hour = (hour == 0) ? 12 : hour
 //Добавляем нулевую цифру к одной цифре минуты
 if (minute < 10) minute = "0" + minute
 // Возвращаем строку
 return hour + ":" + minute + " " + ampm
}

//Функция проверки на високосный год
function isLeapYear(year)
{
 if (year % 4 == 0) return true // Является високосным годом
 return false // Не является високосным годом
}

//Функция возвращает колличество дней в месяце взависимости от года
function getDays(month, year)
{
 // Создаем массив, для хранения числа дней в каждом месяце
 var ar = new Array(12)
 ar[0] = 31 // Январь
 ar[1] = (isLeapYear(year)) ? 29 : 28 // Февраль
 ar[2] = 31 // Март
 ar[3] = 30 // Апрель
 ar[4] = 31 // Май
 ar[5] = 30 // Июнь
 ar[6] = 31 // Июль
 ar[7] = 31 // Август
 ar[8] = 30 // Сентябрь
 ar[9] = 31 // Остябрь
 ar[10] = 30 // Ноябрь
 ar[11] = 31 // Декабрь
 return ar[month]
}

//Функция возвращает название месяца
function getMonthName(month,nameMonth)
{
 // Создаем массив, для хранения названия каждого месяца
 var ar = new Array(12)
if (nameMonth=="rus"||nameMonth=="russ"||nameMonth=="russs")
{

 ar[0] = "Январь"
 ar[1] = "Феврать"
 ar[2] = "Март"
 ar[3] = "Апрель"
 ar[4] = "Май"
 ar[5] = "Июнь"
 ar[6] = "Июль"
 ar[7] = "Август"
 ar[8] = "Сентабрь"
 ar[9] = "Октябрь"
 ar[10] = "Ноябрь"
 ar[11] = "Декабрь"
}else
{
 ar[0] = "January"
 ar[1] = "February"
 ar[2] = "March"
 ar[3] = "April"
 ar[4] = "May"
 ar[5] = "June"
 ar[6] = "July"
 ar[7] = "August"
 ar[8] = "September"
 ar[9] = "October"
 ar[10] = "November"
 ar[11] = "December"
}
 return ar[month]
}

// Функция установки настроек календаря с последующей прорисовкой
function setCalendar()
{

 // Параметры настройки таблицы
 var tableBgColor = "#f0fff0" //Цвет фона таблицы
 var headerHeight = 15 // Высота ячеки заголовка с названием месяца
 var border = 1 // Рамка
 var cellspacing = "1" // Промежуток между ячейками 
 var cellpadding = "1" // Свободное пространство между содержимым ячейки и её границами

 var headerColor = "#ffffff" // Цвет текста заголовка в ячейке
 var headerBgColor = "#006000" // Цвет фона в ячейке заголовка
 var headerSize = "2" // Размер шрифта заголовка
 var headerBold= true // Полужирный шрифта заголовка

 var colWidth = 30 // Ширина столбцов в таблице

 var dayCellHeight = 10 // Высота ячеек содержащих дни недели
 var dayColor = "#006000" // Цвет шрифта, представляющего дни недели
 var dayBgColor = "#ffffff" // Цвет фона ячеек содержащих дни недели
 var dayBold= true //Размер шрифта, представляющего дни недели
 var daySize = 2 // Полужирный шрифт представляющий дни недели

 var cellHeight = 20 // Высота ячеек, представляющих даты в календаре

 var todayColor = "red" // Цвет, определяющий сегодняшнюю дату в календаре
 var todayBgColor = "#e0efe0" // Цвет фона ячейки с сегодняшней датой
 var todayBold = true // Полужирный шрифт представляющий сегодняшнюю дату в календаре
 var todaySize = 2 //Размер шрифта, представляющего сегодняшнюю дату в календаре

 var allDayColor = "#000000" // Цвет, остальных дней в календаре
 var allDayBgColor = "#e0efe0" //Цвет фона остальных ячеек
 var allDayBold= false // Полужирный шрифт представляющий остальные дни
 var allDaySize= 2 //Размер шрифта, представляющего остальные дни

 var timeColor = "blue" // Цвет выводимого времени
 var timeSize = "1" //Размер шрифта выводимого времени
 var timeBold = false // Полужирный шрифт выводимого времени
 var isTime = true //Выводить время или нет
 var nameMonth="rus" // rus, russ, russs, eng, engs, engss
 drawCalendar(
  tableBgColor,
  headerHeight,
  border,
  cellspacing,
  cellpadding,
  headerColor,
  headerBgColor,
  headerSize,
  headerBold,
  colWidth,
  dayCellHeight,
  dayColor,
  dayBgColor,
  dayBold,
  daySize,
  cellHeight,
  todayColor,
  todayBgColor,
  todayBold,
  todaySize,
  allDayColor,
  allDayBgColor,
  allDayBold,
  allDaySize,
  timeColor,
  timeSize,
  timeBold,
  isTime,
  nameMonth)
}


// Функция рисования календаря
function drawCalendar(
 tableBgColor,
 headerHeight,
 border,
 cellspacing,
 cellpadding,
 headerColor,
 headerBgColor,
 headerSize,
 headerBold,
 colWidth,
 dayCellHeight,
 dayColor,
 dayBgColor,
 dayBold,
 daySize,
 cellHeight,
 todayColor,
 todayBgColor,
 todayBold,
 todaySize,
 allDayColor,
 allDayBgColor,
 allDayBold,
 allDaySize,
 timeColor,
 timeSize,
 timeBold,
 isTime,
 nameMonth)
{
 // Переменные 
 var now = new Date()
 var year = now.getYear()
 var month = now.getMonth()
 var monthName = getMonthName(month, nameMonth)
 var date = now.getDate()
 now = null
 var firstDayInstance = new Date(year, month, 1)
 var firstDay = firstDayInstance.getDay()+1
 firstDayInstance = null
 // Число дней в текущем месяце
 var lastDate= getDays(month, year)
 // Создаем основную структуру таблицы
 var text = "" 
 text += '<table border=' + border + ' cellspacing=' + cellspacing + 
  ' cellpadding='+cellpadding+' bgcolor='+tableBgColor+'>'
 text += '<th colspan=7 height=' + headerHeight +' bgcolor='+headerBgColor+ '>'
 text += '<font color="' + headerColor + '" size=' + headerSize + '>'
 if(headerBold)text+='<b>'
 text += monthName + ' ' + year 
 if(headerBold)text+='</b>'
 text += '</font>'
 text += '</th>'
 var openCol = '<td width=' + colWidth + ' height=' + dayCellHeight + ' bgcolor='+
  dayBgColor+'>'
 openCol+='<font color="' + dayColor + '" size='+daySize+'>'
 if(dayBold)openCol+='<b>'
 var closeCol = '</font></td>'
 if(dayBold)closeCol='</b>'+closeCol
 // Создаем массив сокращенных названий дней недели
 var weekDay = new Array(7)
 if(nameMonth=="rus")
 {
  weekDay[0] = "Пн"
  weekDay[1] = "ВТ"
  weekDay[2] = "Ср"
  weekDay[3] = "Чт"
  weekDay[4] = "Пт"
  weekDay[5] = "Сб"
  weekDay[6] = "Вс"         
 }
 else if(nameMonth=="russ")
 {
  weekDay[0] = "пн"
  weekDay[1] = "вт"
  weekDay[2] = "ср"
  weekDay[3] = "чт"
  weekDay[4] = "пт"
  weekDay[5] = "сб"
  weekDay[6] = "вс"         
 }
 else if(nameMonth=="russs")
 {
  weekDay[0] = "п"
  weekDay[1] = "в"
  weekDay[2] = "с"
  weekDay[3] = "ч"
  weekDay[4] = "п"
  weekDay[5] = "с"
  weekDay[6] = "в"         
 }
 else if(nameMonth=="eng")
 {
  weekDay[0] = "Mon"
  weekDay[1] = "Tues"
  weekDay[2] = "Wed"
  weekDay[3] = "Thu"
  weekDay[4] = "Fri"
  weekDay[5] = "Sat"
  weekDay[6] = "Sun"         
 }
 else if(nameMonth=="engs")
 {
  weekDay[0] = "Mo"
  weekDay[1] = "Tu"
  weekDay[2] = "We"
  weekDay[3] = "Th"
  weekDay[4] = "Fr"
  weekDay[5] = "Sa"
  weekDay[6] = "Su"         
 }
 else if(nameMonth=="engss")
 {
  weekDay[0] = "m"
  weekDay[1] = "t"
  weekDay[2] = "w"
  weekDay[3] = "t"
  weekDay[4] = "f"
  weekDay[5] = "s"
  weekDay[6] = "s"
 }
 text += '<tr align="center" valign="center">'
 for (var dayNum = 0; dayNum < 7; ++dayNum)
 {
  text += openCol + weekDay[dayNum] + closeCol 
 }
 text += '</tr>'
 var digit = 1
 var curCell = 2
 for (var row = 1; row <= Math.ceil((lastDate + firstDay - 1) / 7); ++row)
 {
  text += '<tr align="right" valign="top">'
  for (var col = 1; col <= 7; ++col)
  {
   if (digit > lastDate) break
   if (curCell < firstDay)
   {
    text += '<td><font size='+allDaySize+' color='+allDayColor+
     '> </font></td>'
    curCell++
   } 
   else
   {
    if (digit == date) 
    { // Текущая ячейка представляет сегодняшнюю дату
     text += '<td height=' + cellHeight + ' bgcolor='+todayBgColor+'>'
     text += '<font color="' + todayColor + '" size='+todaySize+'>'
     if(todayBold)text +='<b>'
     text += digit
     if(todayBold)text +='</b>'
     text += '</font>'
     //Вывод времени
     if(isTime)
     {
      text += '<br>'
      text += '<font color="' + timeColor + '" size='+timeSize+'>'
      text += '<center>' 
      if(timeBold)text +='<b>'
      text += getTime() 
      if(timeBold)text +='</b>'
      text += '</center>'
      text += '</font>'
     }
     text += '</td>'
    } 
    else 
    {
     text += '<td height=' + cellHeight + ' bgcolor='+allDayBgColor+
     '><font size='+allDaySize+' color='+allDayColor+'>'
     if(allDayBold)text +='<b>'
     text +=digit 
     if(allDayBold)text +='</b>'
     text +='</font></td>'
    }
    digit++
   }
  }
  text += '</tr>'
 }
 text += '</table>'
 // Выводим полученную строку
 document.write(text) 
}

// -->
</script>
</head>
<body bgColor="#ffffff">

<script language="JavaScript">
<!--

setCalendar()
// -->
</script>
</body>
</html>

