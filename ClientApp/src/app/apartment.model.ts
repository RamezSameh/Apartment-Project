export interface Apartment {
  id: number;
  title: string;
  location?: string;
  description?: string;
  price: number;
  isAvailable: boolean;
  listingType: 'Rent' | 'Sale';
  photoBase64?: string;
}
