import { Component, OnInit } from "@angular/core";
import { Observable, of, Subject } from "rxjs";
import { Breed } from "../../models/breed";
import { CatsApiService } from "../../services/cats-api/cats-api-service";
import { debounceTime, distinctUntilChanged, switchMap } from 'rxjs/operators';

@Component({
    selector: 'breed-search',
    templateUrl: './breed-search.component.html',
    styleUrls:[ './breed-search.component.css' ]
})
export class BreedSearchComponent implements OnInit {
    breeds$!: Observable<Breed[]>;
    selectedImageUrls$!: Observable<string[]>;
    selectedBreed!: Breed;
    private searchTerms = new Subject<string>();

    constructor(private catsApiService: CatsApiService){}

    ngOnInit(): void {
        this.breeds$ = this.searchTerms.pipe(
            debounceTime(300),
            distinctUntilChanged(),
            switchMap((term:string) => {
                return term ? this.catsApiService.searchBreeds(term) : of([])
            })
        );
    }

    search(term: string): void {
        this.searchTerms.next(term);
    }

    selectBreed(breed: Breed): void {
        this.searchTerms.next("");
        this.selectedImageUrls$ = this.catsApiService.getImageUrl(breed.id);
        this.selectedBreed = breed;
    }
}