export interface Apartment {
  id: number;
  title: string;
  location?: string;
  description?: string;
  price: number;
  isAvailable: boolean;
  photoBase64?: string;
}
