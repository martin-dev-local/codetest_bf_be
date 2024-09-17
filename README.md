
Ett någorlunda komplett WEB API utefter beskrivning.

Något som inte är implementerat är versionshantering för att säkra att uppdatering av en post som har ändrats misslyckas,
som att införa en versionskolumn som följer med vid uppdatering och jämförs vid uppdatering av en post. Om värdena skiljer sig
åt ska transaktion rullas tillbaka.

Ingen gräns inlagd för antal i svaret eller pagination implementerad.

DataRepository kunde delats in i fler individuella repositories.

Loggning kunde lagts in i synnerhet för spår eller debug som då också behöver saniteras innan det sparas i DB.
