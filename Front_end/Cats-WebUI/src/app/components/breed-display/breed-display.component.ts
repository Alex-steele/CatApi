import { Component, Input, OnChanges } from "@angular/core";
import { Breed } from "src/app/models/breed";

@Component({
    selector: 'breed-display',
    templateUrl: './breed-display.component.html',
})
export class BreedDisplayComponent implements OnChanges {
    @Input() breed: Breed;
    @Input() imageUrls: Breed;
    seeMore: boolean = false;

    activateSeeMore() {
        this.seeMore = !this.seeMore;
    }

    ngOnChanges() {
        this.seeMore = false;
    }
}
