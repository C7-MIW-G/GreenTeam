using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GreenTeam.Migrations
{
    public partial class MigrateSeedAppUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "20fc5ce4-8a75-4808-99f8-cb5c43ba6d72");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "86d1b277-8b29-436a-b449-90320cd9779b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bca6b676-85d9-4737-8dff-a21b1708e32e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d356bc6c-2f41-4a96-b500-359cd8fe008e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d9ef8fe1-a012-42b4-917d-ff4aa7af2c6d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f9f1d318-e966-4f44-925c-5b661f94ae98");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "20fc5ce4-8a75-4808-99f8-cb5c43ba6d72", 0, "b3c60edf-6712-4ad8-a855-3da62c3b6dbd", "sylvia@greenteam.com", true, "Sylvia Albers", false, null, "SYLVIA@GREENTEAM.COM", "SYLVIA@GREENTEAM.COM", "AQAAAAEAACcQAAAAEIp/RJZNX9ODQEdbeD766nd8kd8pvjiu5RN47mUGMRxptATu/SZc9Xikbh6K1IAQvw==", "1234567890", false, "68104baa-b634-435f-859e-c0f0aa813780", false, "sylvia@greenteam.com" },
                    { "86d1b277-8b29-436a-b449-90320cd9779b", 0, "6e43cf00-8582-4c5d-b5f3-e6ae05651b60", "roy@greenteam.com", true, "Roy Hermans", false, null, "ROY@GREENTEAM.COM", "ROY@GREENTEAM.COM", "AQAAAAEAACcQAAAAEP2UOJaZ9pn7OStYxkpodoLaiX31eNdFNpxGYnnQBRGgRH5Wp9bt4UN01eudmmXItg==", "1234567890", false, "3a8e8304-7bd9-4289-ae6d-6774f7d5f45b", false, "roy@greenteam.com" },
                    { "bca6b676-85d9-4737-8dff-a21b1708e32e", 0, "53ee6d80-9711-4f74-b2fa-b25987ce7213", "noa@greenteam.com", true, "Noa Zeegers", false, null, "NOA@GREENTEAM.COM", "NOA@GREENTEAM.COM", "AQAAAAEAACcQAAAAEJ0/Jhw0gCTXBISbkY9CaVdrGEUpW2UXN+CH0bAGIi5wyUqU5V0KFfTo079pjaZFJA==", "1234567890", false, "cc5a6aba-e395-4c57-83b6-57b6faf49637", false, "noa@greenteam.com" },
                    { "d356bc6c-2f41-4a96-b500-359cd8fe008e", 0, "5b27961e-6454-40e7-a02f-6ddc930a6775", "sem@greenteam.com", true, "Sem Peters", false, null, "SEM@GREENTEAM.COM", "SEM@GREENTEAM.COM", "AQAAAAEAACcQAAAAEGf5CkNvVlIQhRKlD2wa//6AVHtNCNb0LBAyKEZMgYkKtV+JXX1MghCLFrGoKKc16g==", "1234567890", false, "a157c190-1ca7-4bfb-bb19-5650cef39159", false, "sem@greenteam.com" },
                    { "d9ef8fe1-a012-42b4-917d-ff4aa7af2c6d", 0, "de731585-1998-455b-af8c-b550752e27d5", "marcel@greenteam.com", true, "Marcel Klerken", false, null, "MARCEL@GREENTEAM.COM", "MARCEL@GREENTEAM.COM", "AQAAAAEAACcQAAAAEFdQ+nVpIh8gz2hi/Sd2t776sDHvrTGd3f67aGCyv6ktjNEgHiZ3MR9H5Ik/HPqQQQ==", "1234567890", false, "cadec1c1-c5d1-4cb8-9a08-2851391149c2", false, "marcel@greenteam.com" },
                    { "f9f1d318-e966-4f44-925c-5b661f94ae98", 0, "1f228eeb-f6eb-481a-80ef-5d96d47358df", "iris@greenteam.com", true, "Iris Hagen", false, null, "IRIS@GREENTEAM.COM", "IRIS@GREENTEAM.COM", "AQAAAAEAACcQAAAAEG5s1FPdi1uWUT5aMuroJ9Kqp2y63QBxqG7mpB3IEJgY+3niV5vtz9rordJQJuA3jQ==", "1234567890", false, "779dfe33-b7aa-4f35-b5d4-22dacbcc9eb9", false, "iris@greenteam.com" }
                });
        }
    }
}
