grammar Process;
/*
 ������� �������
 */
process: START initProcess END EOF;
initProcess: INIT objectWithProperty+;
/*����� WORD - ��� �������� �������*/
objectWithProperty: WORD PROPERTIES objectProperties;
/*����� WORD - ��� �������� �������� �������*/
objectProperties: (WORD property)+;
property: INCLUDE chainOfCommands;
chainOfCommands: (simplecommand | conditioncommand)+;
simplecommand : COMMAND GAMECOMMANDS;
conditioncommand : CONDITIONCOMMAND 
                   IF (simplecommand | conditioncommand)+
                   THEN (simplecommand | conditioncommand)+
                   (ELSE (simplecommand | conditioncommand)+)?;

/*
 ������� �������
 */
fragment LOWERCASE: [a-z];
fragment UPPERCASE: [A-Z];
fragment NUMBERS: [0-9];
INCLUDE : 'Include';
PROPERTIES : 'Properties';
START: 'Start';
END: 'End';
INIT: 'Init';
WORD: (LOWERCASE | UPPERCASE)+;
COMMAND : 'Command';
GAMECOMMANDS : ('GetClassNumber' | 'GetGroupNumber' | 'CheckAttendance' | 'GetLectureName' | 'TurnOnProjector' | 'OpenLecture' | 'WaitToFinish');
CONDITIONCOMMAND : 'ConditionCommand';
IF : 'If';
THEN : 'Then';
ELSE : 'Else';
WHITESPACE: (' ' | '\t')+ -> skip;
NEWLINE   : ('\r'? '\n' | '\r')+;