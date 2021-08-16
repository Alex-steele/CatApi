export interface Breed extends Readonly<{
    weight: string;

    id: string;

    name: string;

    temperament: string;

    origin: string;

    description: string;

    lifeSpan: string;

    indoor: boolean | null;

    lap: boolean | null;

    affectionLevel: number | null;

    childFriendly: number | null;

    dogFriendly: number | null;

    energyLevel: number | null;

    grooming: number | null;

    healthIssues: number | null;

    intelligence: number | null;

    sheddingLevel: number | null;

    socialNeeds: number | null;

    vocalisation: number | null;

    hairless: boolean | null;

    rare: boolean | null;

    wikipediaUrl: string;

    hypoallergenic: boolean | null;

    referenceImageId: string;
}>{};