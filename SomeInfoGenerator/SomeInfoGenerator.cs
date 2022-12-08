using StorageNameSpace;

namespace SomeInfoGeneratorNameSpace;

public class SomeInfoGenerator
{
    private readonly List<double> dvdCapacityList = new()
    {
        // Вместимость DVD-дисков в Гбайтах.
        4.7, 8.5, 9.4, 17, 18, 25, 26, 27, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49,
        50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60, 61, 62, 63, 64, 65, 66, 67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
        77, 78, 79, 80, 81, 82, 83, 84, 85, 86, 87, 88, 89, 90, 91, 92, 93, 94, 95, 96, 97, 98, 99, 100, 101, 102,
        103, 104, 105, 106, 107, 108, 109, 110, 111, 112, 113, 114, 115, 116, 117, 118, 119, 120, 121, 122, 123,
        124, 125, 126, 127, 128, 129, 130, 131, 132, 133, 134, 135, 136, 137, 138, 139, 140, 141, 142, 143, 144,
        145, 146, 147, 148, 149, 150, 151, 152, 153, 154, 155, 156, 157, 158, 159, 160, 161, 162, 163, 164, 165,
        166, 167, 168, 169, 170, 171, 172, 173, 174, 175, 176, 177, 178, 179, 180, 181, 182, 183, 184, 185, 186, 187
    };

    // DVD fields: string manufacturer, string model, double capacity, int quantity, double writeSpeed.

    private readonly List<string> dvdManufacturerList = new()
    {
        "Hitachi", "JVC", "Matsushita", "Mitsubishi", "Philips", "Pioneer", "Sony", "Thomson", "Time Warner", "Toshiba"
    };

    private readonly List<string> dvdModelList = new()
    {
        "DVD-R", "DVD-RW", "DVD+R", "DVD+RW", "DVD-RAM", "DVD-R DL", "DVD+R DL", "DVD-RW DL", "DVD+RW DL", "DVD-RAM DL"
    };


    private readonly List<double> dvdWriteSpeedList = new()
    {
        // Скорость записи DVD-дисков в Мбит/с.
        1.4, 1.8, 2.4, 2.8, 3.6, 4.0, 4.7, 5.2, 6.0, 6.4, 7.2, 7.6, 8.5, 9.0, 9.6, 10.0, 10.8, 11.2, 12.0, 12.5,
        13.3, 13.8, 14.4, 15.0, 15.6, 16.0, 16.8, 17.3, 18.0, 18.5, 19.2, 19.8, 20.4, 21.0, 21.6, 22.0, 22.8, 23.3,
        24.0, 24.5, 25.2, 25.8, 26.4, 27.0, 27.6, 28.0, 28.8, 29.3, 30.0, 30.5, 31.2, 31.8, 32.4, 33.0, 33.6, 34.0,
        34.8, 35.3, 36.0, 36.5, 37.2, 37.8, 38.4, 39.0, 39.6, 40.0, 40.8, 41.3, 42.0, 42.5, 43.2, 43.8, 44.4, 45.0,
        45.6, 46.0, 46.8, 47.3, 48.0, 48.5, 49.2, 49.8, 50.4, 51.0, 51.6, 52.0, 52.8, 53.3, 54.0, 54.5, 55.2, 55.8,
        56
    };

    private readonly List<int> flashCapacityList = new()
    {
        // Емкость флеш-накопителей в Гб.
        1, 2, 4, 8, 16, 32, 64, 128, 256, 512, 1024, 2048, 4096, 8192, 16384, 32768, 65536, 131072, 262144, 524288
    };

    // Flash fields: string manufacturer, string model, int capacity, int quantity, double speed.

    private readonly List<string> flashManufacturerList = new()
    {
        // Производители флеш-накопителей.
        "ADATA", "Apacer", "Corsair", "Crucial", "Dane-Elec", "Fujitsu", "G.Skill", "HGST", "HP", "Kingston",
        "Lexar", "Micron", "OCZ", "Patriot", "PNY", "Samsung", "SanDisk", "Silicon Power", "Sony", "Transcend",
        "Toshiba", "Verbatim", "Western Digital", "XPG"
    };

    private readonly List<string> flashModelList = new()
    {
        // Модели флеш-накопителей.
        "CZ73", "CZ74", "CZ75", "CZ76", "CZ77", "CZ78", "CZ79", "CZ80", "CZ81", "CZ82", "CZ83", "CZ84", "CZ85",
        "CZ86", "CZ87", "CZ88", "CZ89", "CZ90", "CZ91", "CZ92", "CZ93", "CZ94", "CZ95", "CZ96", "CZ97", "CZ98",
        "CZ99", "CZ100", "CZ101", "CZ102", "CZ103", "CZ104", "CZ105", "CZ106", "CZ107", "CZ108", "CZ109", "CZ110",
        "CZ111", "CZ112", "CZ113", "CZ114", "CZ115", "CZ116", "CZ117", "CZ118", "CZ119", "CZ120", "CZ121", "CZ122",
        "CZ123", "CZ124", "CZ125", "CZ126", "CZ127", "CZ128", "CZ129", "CZ130", "CZ131", "CZ132", "CZ133", "CZ134",
        "CZ135", "CZ136", "CZ137", "CZ138", "CZ139", "CZ140", "CZ141", "CZ142", "CZ143", "CZ144", "CZ145", "CZ146",
        "CZ147", "CZ148", "CZ149", "CZ150", "CZ151", "CZ152", "CZ153", "CZ154", "CZ155", "CZ156", "CZ157", "CZ158",
        "CZ159", "CZ160", "CZ161", "CZ162", "CZ163", "CZ164", "CZ165", "CZ166", "CZ167", "CZ168", "CZ169", "CZ170"
    };

    private readonly List<double> flashSpeedList = new()
    {
        // Скорость чтения/записи флеш-накопителей в Мбит/с.
        1.4, 1.8, 2.4, 2.8, 3.6, 4.0, 4.7, 5.2, 6.0, 6.4, 7.2, 7.6, 8.5, 9.0, 9.6, 10.0, 10.8, 11.2, 12.0, 12.5,
        13.3, 13.8, 14.4, 15.0, 15.6, 16.0, 16.8, 17.3, 18.0, 18.5, 19.2, 19.8, 20.4, 21.0, 21.6, 22.0, 22.8, 23.3,
        24.0, 24.5, 25.2, 25.8, 26.4, 27.0, 27.6, 28.0, 28.8, 29.3, 30.0, 30.5, 31.2, 31.8, 32.4, 33.0, 33.6, 34.0,
        34.8, 35.3, 36.0, 36.5, 37.2, 37.8, 38.4, 39.0, 39.6, 40.0, 40.8, 41.3, 42.0, 42.5, 43.2, 43.8, 44.4, 45.0,
        45.6, 46.0, 46.8, 47.3, 48.0, 48.5, 49.2, 49.8, 50.4, 51.0, 51.6, 52.0, 52.8, 53.3, 54.0, 54.5
    };

    private readonly List<double> hddCapacityList = new()
    {
        // Емкость жестких дисков в Гб.
        1, 2, 4, 8, 16, 32, 64, 128, 256, 512, 1024, 2048, 4096, 8192, 16384, 32768, 65536, 131072, 262144, 524288
    };

    // HDD fields: string manufacturer, string model, double capacity, int quantity, double spindleSpeed.
    private readonly List<string> hddManufacturerList = new()
    {
        // Производители жестких дисков.
        "Acer", "Apple", "Asus", "Buffalo", "Dell", "Fujitsu", "Hitachi", "HP", "IBM", "Intel", "Kingston",
        "Lenovo", "LG", "Maxtor", "Micron", "MSI", "Nikon", "OCZ", "Panasonic", "Plextor", "Samsung", "Seagate",
        "Sony", "Toshiba", "Western Digital"
    };

    private readonly List<string> hddModelList = new()
    {
        // Модели жестких дисков разных производителей.
        "HDD1", "HDD2", "HDD3", "HDD4", "HDD5", "HDD6", "HDD7", "HDD8", "HDD9", "HDD10", "HDD11", "HDD12", "HDD13"
    };

    private readonly List<double> hddSpindleSpeedList = new()
    {
        // Скорость вращения шпинделя жестких дисков в об/мин.
        5400, 7200, 10000, 15000, 20000, 25000, 30000, 35000, 40000, 45000, 50000, 55000, 60000, 65000, 70000, 75000,
        80000, 85000, 90000, 95000, 100000, 105000, 110000, 115000, 120000, 125000, 130000, 135000, 140000, 145000,
        150000, 155000, 160000, 165000, 170000, 175000, 180000, 185000, 190000, 195000, 200000, 205000, 210000, 215000,
        220000, 225000, 230000, 235000, 240000, 245000, 250000, 255000, 260000, 265000, 270000, 275000, 280000, 285000,
        290000, 295000, 300000, 305000, 310000, 315000, 320000, 325000, 330000, 335000, 340000, 345000, 350000, 355000,
        360000, 365000, 370000, 375000, 380000, 385000, 390000, 395000, 400000, 405000, 410000, 415000, 420000, 425000,
        430000, 435000, 440000, 445000, 450000, 455000, 460000, 465000, 470000, 475000, 480000, 485000, 490000, 495000,
        500000, 505000, 510000, 515000, 520000, 525000, 530000, 535000, 540000, 545000, 550000, 555000, 560000, 565000
    };

    private int storageRandomQuantity()
    {
        var random = new Random();
        return random.Next(1, 1000);
    }

    public void FillUpDVD(ref DVD dvd)
    {
        var random = new Random();
        dvd.Manufacturer = dvdManufacturerList.ElementAtOrDefault(random.Next(0, dvdManufacturerList.Count - 1));
        dvd.Model = dvdModelList.ElementAtOrDefault(random.Next(0, dvdModelList.Count - 1));
        dvd.Capacity = dvdCapacityList.ElementAtOrDefault(random.Next(0, dvdCapacityList.Count - 1));
        dvd.Quantity = storageRandomQuantity();
        dvd.WriteSpeed = dvdWriteSpeedList.ElementAtOrDefault(random.Next(0, dvdWriteSpeedList.Count - 1));
    }

    public void FillUpFlash(ref Flash flash)
    {
        var random = new Random();
        flash.Manufacturer = flashManufacturerList.ElementAtOrDefault(random.Next(0, flashManufacturerList.Count - 1));
        flash.Model = flashModelList.ElementAtOrDefault(random.Next(0, flashModelList.Count - 1));
        flash.Capacity = flashCapacityList.ElementAtOrDefault(random.Next(0, flashCapacityList.Count - 1));
        flash.Quantity = storageRandomQuantity();
        flash.Speed = flashSpeedList.ElementAtOrDefault(random.Next(0, flashSpeedList.Count - 1));
    }

    public void FillUpHDD(ref HDD hdd)
    {
        var random = new Random();
        hdd.Manufacturer = hddManufacturerList.ElementAtOrDefault(random.Next(0, hddManufacturerList.Count - 1));
        hdd.Model = hddModelList.ElementAtOrDefault(random.Next(0, hddModelList.Count - 1));
        hdd.Capacity = hddCapacityList.ElementAtOrDefault(random.Next(0, hddCapacityList.Count - 1));
        hdd.Quantity = storageRandomQuantity();
        hdd.SpindleSpeed = hddSpindleSpeedList.ElementAtOrDefault(random.Next(0, hddSpindleSpeedList.Count - 1));
    }
}