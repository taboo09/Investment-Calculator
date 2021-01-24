CREATE TABLE "Files" (
	"FileId"	INTEGER NOT NULL,
	"FileName"	TEXT NOT NULL,
	"FileInfo"	TEXT,
	"Extension"	TEXT NOT NULL,
	"Market"	TEXT,
	"OriginalName"	TEXT NOT NULL,
	"PeriodYears"	INTEGER,
	"CreatedAt"	TEXT NOT NULL,
	PRIMARY KEY("FileId" AUTOINCREMENT)
);