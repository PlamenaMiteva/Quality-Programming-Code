namespace VehicleParkingSystemApp.Core
{
    using System;

    public class Layout
    {
        private int sectors;
        private int sectorPlacesNumber;

        public Layout(int numberOfSectorsCount, int sectorPlacesPerSector)
        {
            this.SectorsCount = numberOfSectorsCount;
            this.sectorPlacesNumber = sectorPlacesPerSector;
        }

        public int SectorsCount
        {
            get
            {
                return this.sectors;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The number of sectorsCount must be positive.");
                }

                this.sectors = value;
            }
        }

        public int SectorPlacesNumber
        {
            get
            {
                return this.sectorPlacesNumber;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The number of places per sector must be positive.");
                }

                this.sectorPlacesNumber = value;
            }
        }
    }
}
