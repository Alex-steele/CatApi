import { Component, OnInit } from "@angular/core";
import { Observable, Subject } from "rxjs";
import { Breed } from "../models/breed";
import { BreedService } from "../services/cats-api/cats-api-service";
import { debounceTime, distinctUntilChanged, switchMap } from 'rxjs/operators';

@Component({
    selector: 'breed-search',
    templateUrl: './breed-search.component.html',
})
export class BreedSearchComponent implements OnInit {
    breeds$!: Observable<Breed[]>;
    private searchTerms = new Subject<string>();
    selectedBreed!: Breed;

    constructor(private breedService: BreedService){}

    ngOnInit(): void {
        this.breeds$ = this.searchTerms.pipe(
            debounceTime(500),
            distinctUntilChanged(),
            switchMap((term:string) => this.breedService.searchBreeds(term))
        );
    }

    search(term: string): void {
        this.searchTerms.next(term);
    }

    selectBreed(breed: Breed): void {
        this.searchTerms.next("");
        this.selectedBreed = breed;
    }
}