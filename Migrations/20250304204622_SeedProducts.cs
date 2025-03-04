using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Bangazon.Migrations
{
    /// <inheritdoc />
    public partial class SeedProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Image", "IsAvailable", "Name", "Price", "Quantity", "SellerId" },
                values: new object[,]
                {
                    { 1, 1, "Fleetwood Mac's best-selling album.", "https://m.media-amazon.com/images/I/71WxpWovLTL._SL1500_.jpg", true, "Rumours", 47.36m, 5, "BCyBV6WJpTZcPG0b0WMfr8vJM1B3" },
                    { 2, 1, "Classic Pink Floyd album.", "https://m.media-amazon.com/images/I/81j3Su+bWjL._SL1500_.jpg", true, "Dark Side of the Moon", 51.99m, 3, "BCyBV6WJpTZcPG0b0WMfr8vJM1B3" },
                    { 3, 1, "The Beatles' famous album.", "https://m.media-amazon.com/images/I/81Sl5vNuxBL._SL1500_.jpg", true, "Abbey Road", 38.50m, 7, "BCyBV6WJpTZcPG0b0WMfr8vJM1B3" },
                    { 4, 2, "Alanis Morissette's breakthrough album.", "https://m.media-amazon.com/images/I/71+WumJptUL._SL1400_.jpg", true, "Jagged Little Pill", 15.99m, 4, "BCyBV6WJpTZcPG0b0WMfr8vJM1B3" },
                    { 5, 2, "Nirvana's best-known record.", "https://m.media-amazon.com/images/I/71NRSUUMZXL._SL1400_.jpg", true, "Nevermind", 29.99m, 6, "BCyBV6WJpTZcPG0b0WMfr8vJM1B3" },
                    { 6, 3, "Adele's Grammy-winning album.", "https://m.media-amazon.com/images/I/71d3FbEovhL._SL1400_.jpg", true, "21", 19.99m, 3, "BCyBV6WJpTZcPG0b0WMfr8vJM1B3" },
                    { 7, 3, "Lady Gaga's iconic album.", "https://m.media-amazon.com/images/I/91m3bJ6geTL._SL1500_.jpg", true, "Born This Way", 22.99m, 2, "BCyBV6WJpTZcPG0b0WMfr8vJM1B3" },
                    { 8, 1, "Michael Jackson's best-selling album.", "https://m.media-amazon.com/images/I/81WcnNQ-TBL._SL1500_.jpg", true, "Thriller", 45.00m, 9, "BCyBV6WJpTZcPG0b0WMfr8vJM1B3" },
                    { 9, 1, "Pink Floyd's rock opera.", "https://m.media-amazon.com/images/I/71OQVoZt3ML._SL1500_.jpg", true, "The Wall", 50.00m, 4, "BCyBV6WJpTZcPG0b0WMfr8vJM1B3" },
                    { 10, 2, "AC/DC's legendary album.", "https://m.media-amazon.com/images/I/61wq4+PxvFL._SL1400_.jpg", true, "Back in Black", 39.99m, 8, "BCyBV6WJpTZcPG0b0WMfr8vJM1B3" },
                    { 11, 1, "Taylor Swift's 2019 album with pop anthems.", "https://m.media-amazon.com/images/I/81zWwCEXKPL._SL1500_.jpg", true, "Lover", 39.99m, 5, "LoBA4EB98KfPtTZ7t8hE2xlbURw1" },
                    { 12, 1, "Taylor Swift's award-winning album from 2014.", "https://m.media-amazon.com/images/I/71r44eosF8L._SL1500_.jpg", true, "1989", 42.99m, 6, "LoBA4EB98KfPtTZ7t8hE2xlbURw1" },
                    { 13, 1, "Kacey Musgraves' Grammy-winning country album.", "https://m.media-amazon.com/images/I/81g8mMUxsnL._SL1500_.jpg", true, "Golden Hour", 35.99m, 4, "LoBA4EB98KfPtTZ7t8hE2xlbURw1" },
                    { 14, 1, "Taylor Swift's re-recorded classic country-pop album.", "https://m.media-amazon.com/images/I/81bIVb9zTxL._SL1500_.jpg", true, "Fearless (Taylor's Version)", 36.50m, 7, "LoBA4EB98KfPtTZ7t8hE2xlbURw1" },
                    { 15, 1, "Taylor Swift's re-recording of her hit album Speak Now.", "https://m.media-amazon.com/images/I/71qNte6mGBL._SL1500_.jpg", true, "Speak Now (Taylor's Version)", 45.99m, 3, "LoBA4EB98KfPtTZ7t8hE2xlbURw1" },
                    { 16, 1, "Folklore's sister album from Taylor Swift.", "https://m.media-amazon.com/images/I/71JJ0VdEP3L._SL1400_.jpg", true, "Evermore", 38.00m, 6, "LoBA4EB98KfPtTZ7t8hE2xlbURw1" },
                    { 17, 1, "Taylor Swift's highly anticipated 2022 album.", "https://m.media-amazon.com/images/I/71g2zPSy7cL._SL1500_.jpg", true, "Midnights", 39.50m, 5, "LoBA4EB98KfPtTZ7t8hE2xlbURw1" },
                    { 18, 1, "Indie-folk album from Taylor Swift featuring Bon Iver.", "https://m.media-amazon.com/images/I/71A8kMA6lsL._SL1500_.jpg", true, "Folklore", 37.99m, 4, "LoBA4EB98KfPtTZ7t8hE2xlbURw1" },
                    { 19, 1, "Taylor Swift's dark-pop comeback album.", "https://m.media-amazon.com/images/I/71-H5A-YxjL._SL1400_.jpg", true, "Reputation", 41.99m, 8, "LoBA4EB98KfPtTZ7t8hE2xlbURw1" },
                    { 20, 1, "Taylor Swift's iconic breakup album, re-recorded.", "https://m.media-amazon.com/images/I/61KtbxdHUtL._SL1500_.jpg", true, "Red (Taylor's Version)", 49.99m, 9, "LoBA4EB98KfPtTZ7t8hE2xlbURw1" },
                    { 21, 1, "The Doors' legendary debut album featuring 'Light My Fire'.", "https://m.media-amazon.com/images/I/81XwnMK0lnL._SL1500_.jpg", true, "The Doors", 28.99m, 6, "9a53d726-a2cd-42df-9d0f-5ae1a45c1c75" },
                    { 22, 1, "U2's breakthrough album featuring 'With or Without You'.", "https://m.media-amazon.com/images/I/61Qx3-iADfL._SL1200_.jpg", true, "The Joshua Tree", 29.99m, 6, "9a53d726-a2cd-42df-9d0f-5ae1a45c1c75" },
                    { 23, 1, "The Beatles' experimental classic from 1966.", "https://m.media-amazon.com/images/I/71-1XnQy3-L._SL1500_.jpg", true, "Revolver", 31.50m, 4, "9a53d726-a2cd-42df-9d0f-5ae1a45c1c75" },
                    { 24, 1, "Queen's epic album featuring 'Bohemian Rhapsody'.", "https://m.media-amazon.com/images/I/71sN5JB01cL._SL1500_.jpg", true, "A Night at the Opera", 38.99m, 7, "9a53d726-a2cd-42df-9d0f-5ae1a45c1c75" },
                    { 25, 1, "Jimi Hendrix's groundbreaking double album.", "https://m.media-amazon.com/images/I/71J07CmmyxL._SL1200_.jpg", true, "Electric Ladyland", 36.99m, 5, "9a53d726-a2cd-42df-9d0f-5ae1a45c1c75" },
                    { 26, 1, "David Bowie's concept album featuring 'Starman'.", "https://m.media-amazon.com/images/I/81Ox3bH8K9L._SL1500_.jpg", true, "The Rise and Fall of Ziggy Stardust", 27.99m, 6, "9a53d726-a2cd-42df-9d0f-5ae1a45c1c75" },
                    { 27, 1, "Dire Straits' biggest album featuring 'Money for Nothing'.", "https://m.media-amazon.com/images/I/71b6M0XLvSL._SL1500_.jpg", true, "Brothers in Arms", 32.99m, 5, "9a53d726-a2cd-42df-9d0f-5ae1a45c1c75" },
                    { 28, 1, "Van Morrison’s most celebrated album, featuring 'Into the Mystic'.", "https://m.media-amazon.com/images/I/81Ug7cMZk8L._SL1500_.jpg", true, "Moondance", 31.99m, 5, "9a53d726-a2cd-42df-9d0f-5ae1a45c1c75" },
                    { 29, 1, "A highly influential album with Andy Warhol's iconic banana cover.", "https://m.media-amazon.com/images/I/81vBx5EmKXL._SL1500_.jpg", true, "The Velvet Underground & Nico", 39.99m, 6, "9a53d726-a2cd-42df-9d0f-5ae1a45c1c75" },
                    { 30, 1, "Another classic from David Bowie featuring 'Life on Mars?'.", "https://m.media-amazon.com/images/I/81a1DlQF7hL._SL1500_.jpg", true, "Hunky Dory", 30.99m, 7, "9a53d726-a2cd-42df-9d0f-5ae1a45c1c75" },
                    { 31, 1, "The Clash's iconic punk rock double album.", "https://m.media-amazon.com/images/I/81AwUyc+KHL._SL1500_.jpg", true, "London Calling", 37.99m, 6, "fa80e4a1-53b7-4784-ab59-6574dea65bb0" },
                    { 32, 1, "Prince's legendary album featuring 'When Doves Cry'.", "https://m.media-amazon.com/images/I/81TlfZbcY+L._SL1500_.jpg", true, "Purple Rain", 33.50m, 5, "fa80e4a1-53b7-4784-ab59-6574dea65bb0" },
                    { 33, 1, "Bruce Springsteen's breakthrough album.", "https://m.media-amazon.com/images/I/91pGDOS2yYL._SL1500_.jpg", true, "Born to Run", 28.99m, 7, "fa80e4a1-53b7-4784-ab59-6574dea65bb0" },
                    { 34, 1, "The Beach Boys' classic album that redefined pop music.", "https://m.media-amazon.com/images/I/81ZXxdrUwcL._SL1500_.jpg", true, "Pet Sounds", 36.99m, 5, "fa80e4a1-53b7-4784-ab59-6574dea65bb0" },
                    { 35, 1, "Eagles' legendary album featuring the title track.", "https://m.media-amazon.com/images/I/71iCZPH5DqL._SL1500_.jpg", true, "Hotel California", 34.99m, 4, "fa80e4a1-53b7-4784-ab59-6574dea65bb0" },
                    { 36, 1, "Carole King's masterpiece featuring 'You've Got a Friend'.", "https://m.media-amazon.com/images/I/91wPiHtmwQL._SL1500_.jpg", true, "Tapestry", 27.99m, 6, "fa80e4a1-53b7-4784-ab59-6574dea65bb0" },
                    { 37, 1, "Simon & Garfunkel's classic folk-rock album.", "https://m.media-amazon.com/images/I/81KrqZuxNQL._SL1500_.jpg", true, "Bridge Over Troubled Water", 32.99m, 5, "fa80e4a1-53b7-4784-ab59-6574dea65bb0" },
                    { 38, 1, "Curtis Mayfield's groundbreaking soul-funk album.", "https://m.media-amazon.com/images/I/91RCpMFXxQL._SL1500_.jpg", true, "Superfly", 31.50m, 4, "fa80e4a1-53b7-4784-ab59-6574dea65bb0" },
                    { 39, 1, "Bob Dylan's deeply personal masterpiece.", "https://m.media-amazon.com/images/I/81DBw5cAzQL._SL1500_.jpg", true, "Blood on the Tracks", 35.50m, 6, "fa80e4a1-53b7-4784-ab59-6574dea65bb0" },
                    { 40, 1, "The Beatles' final studio album.", "https://m.media-amazon.com/images/I/71qlM3JjXQL._SL1500_.jpg", true, "Let It Be", 30.99m, 7, "fa80e4a1-53b7-4784-ab59-6574dea65bb0" },
                    { 41, 1, "Beastie Boys' genre-defining hip-hop album.", "https://m.media-amazon.com/images/I/91tZCYO2iIL._SL1500_.jpg", true, "Licensed to Ill", 27.99m, 5, "2fe66f47-afdb-4a83-9dff-2d8e60b51b7a" },
                    { 42, 1, "The Smiths’ iconic post-punk album.", "https://m.media-amazon.com/images/I/81G7lzC5VLL._SL1500_.jpg", true, "The Queen Is Dead", 34.99m, 6, "2fe66f47-afdb-4a83-9dff-2d8e60b51b7a" },
                    { 43, 1, "Red Hot Chili Peppers’ funk-rock breakthrough.", "https://m.media-amazon.com/images/I/71GywSYBKlL._SL1500_.jpg", true, "Blood Sugar Sex Magik", 33.50m, 4, "2fe66f47-afdb-4a83-9dff-2d8e60b51b7a" },
                    { 44, 1, "R.E.M.'s critically acclaimed album.", "https://m.media-amazon.com/images/I/81wUOBjHboL._SL1500_.jpg", true, "Automatic for the People", 36.99m, 7, "2fe66f47-afdb-4a83-9dff-2d8e60b51b7a" },
                    { 45, 1, "The Pixies’ alternative rock classic.", "https://m.media-amazon.com/images/I/81s6KZp1ajL._SL1500_.jpg", true, "Doolittle", 30.99m, 6, "2fe66f47-afdb-4a83-9dff-2d8e60b51b7a" },
                    { 46, 1, "Patti Smith's influential punk album.", "https://m.media-amazon.com/images/I/81MbMS+FDsL._SL1500_.jpg", true, "Horses", 38.99m, 5, "2fe66f47-afdb-4a83-9dff-2d8e60b51b7a" },
                    { 47, 1, "Guns N' Roses' explosive debut album.", "https://m.media-amazon.com/images/I/81pLDAZV4LL._SL1500_.jpg", true, "Appetite for Destruction", 29.99m, 5, "2fe66f47-afdb-4a83-9dff-2d8e60b51b7a" },
                    { 48, 1, "Fleetwood Mac’s most celebrated album.", "https://m.media-amazon.com/images/I/81vw+8N6WQL._SL1500_.jpg", true, "Rumours", 35.99m, 7, "2fe66f47-afdb-4a83-9dff-2d8e60b51b7a" },
                    { 49, 1, "AC/DC’s best-selling rock album of all time.", "https://m.media-amazon.com/images/I/81zBfuU6+RL._SL1500_.jpg", true, "Back in Black", 37.50m, 6, "2fe66f47-afdb-4a83-9dff-2d8e60b51b7a" },
                    { 50, 1, "Metallica’s iconic thrash metal album.", "https://m.media-amazon.com/images/I/91zRVgJavIL._SL1500_.jpg", true, "Master of Puppets", 33.99m, 5, "2fe66f47-afdb-4a83-9dff-2d8e60b51b7a" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 50);
        }
    }
}
