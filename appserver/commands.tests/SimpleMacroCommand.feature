﻿Функция: Простая составная каоманда. 

Простая составная команда позволяет выполнить последовательность команд
как одну команду. В случае выброса исклчения из любой команды последовательности
выполнение последовательности останавливается, а макрокоманда пробрасывает
исключение дальше.

@Позитивный
Сценарий: Макрокоманда выполняет все команды последовательности
	Дано макрокоманда, собранная из последовательности команд
	Когда макрокоманда выполняется 
	Тогда выполняются все команды последовательности.

Сценарий: Выполнение макрокоманды прерывается на команде, которая вбрасывает исключение
	Дано макрокоманда, собранная из последовательности команд, одна из которых выбрасвает исключение
	Когда макрокоманда выполняется 
	Тогда макрокоманда прервывается выброшенным исключением.


