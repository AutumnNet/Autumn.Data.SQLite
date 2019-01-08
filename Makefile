SDK := 4.6
CC := mcs -sdk:$(SDK)
CONTRIB = ./contrib/
AUTUMN = ./packages/Autumn.Net.0.1.5/lib/net46/Autumn.Net.dll
AUTUMN_DATA = ./packages/Autumn.Net.Data.0.1.6/lib/net46/Autumn.Net.Data.dll

all:
	echo "build"

fw:
	$(CC) -platform:x86 \
		-target:library \
		-out:./Autumn.Data.SQLite/bin/Debug/Autumn.Data.SQLite.dll \
		-r:System.Data.dll \
		-r:$(AUTUMN) \
		-r:$(AUTUMN_DATA) \
		-r:$(CONTRIB)/System.Data.SQLite.dll \
		./Autumn.Data.SQLite/SQLiteService.cs
