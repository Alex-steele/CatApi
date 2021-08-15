export interface Breed extends Readonly<{
    weight: Weight;

    id: string;

    name: string;

    cfaUrl: string;

    vetstreetUrl: string;

    vcahospitalsUrl: string;

    temperament: string;

    origin: string;

    countryCodes: string;

    countryCode: string;

    description: string;

    lifeSpan: string;

    indoor: boolean | null;

    lap: boolean | null;

    altNames: string;

    adaptability: number | null;

    affectionLevel: number | null;

    childFriendly: number | null;

    dogFriendly: number | null;

    energyLevel: number | null;

    grooming: number | null;

    healthIssues: number | null;

    intelligence: number | null;

    sheddingLevel: number | null;

    socialNeeds: number | null;

    strangerFriendly: number | null;

    vocalisation: number | null;

    experimental: boolean | null;

    hairless: boolean | null;

    natural: boolean | null;

    rare: boolean | null;

    rex: boolean | null;

    suppressedTail: boolean | null;

    shortLegs: boolean | null;

    wikipediaUrl: string;

    hypoallergenic: boolean | null;

    referenceImageId: string;
}>{};

export interface Weight extends Readonly<{
    imperial: string;
    metric: string;
}>{};