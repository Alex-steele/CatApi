import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { TestBed } from '@angular/core/testing';
import { defer } from 'rxjs';
import { Breed } from 'src/app/models/breed';
import { CatsApiService } from './cats-api-service';

describe('CatsApiService', () => {
  let service: CatsApiService;
  let httpClientSpy: { get: jasmine.Spy };

  beforeEach(() => {
    httpClientSpy = jasmine.createSpyObj('HttpClient', ['get']);
    TestBed.configureTestingModule({
      providers: [
        CatsApiService,
        { provide: HttpClient, useValue: httpClientSpy }
      ]
    });
    service = TestBed.inject(CatsApiService);
    httpClientSpy = TestBed.inject(HttpClient) as jasmine.SpyObj<HttpClient>;
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  describe('searchBreeds', () => {

    it('should return expected breeds', () => {
      const expectedBreeds: Breed[] = [
        {
          weight: "Test",
          id: "Test",
          name: "Test",
          temperament: "Test",
          origin: "Test",
          description: "Test",
          lifeSpan: "Test",
          indoor: true,
          lap: false,
          affectionLevel: 5,
          childFriendly: 2,
          dogFriendly: 3,
          energyLevel: 2,
          grooming: 5,
          healthIssues: 4,
          intelligence: 2,
          sheddingLevel: 3,
          socialNeeds: 2,
          vocalisation: 4,
          hairless: false,
          rare: true,
          wikipediaUrl: "Test",
          hypoallergenic: false,
          referenceImageId: "Test",
        }
      ]

      httpClientSpy.get.and.returnValue(asyncData(expectedBreeds));

      service.searchBreeds("Test").subscribe(
        result => expect(result).toEqual(expectedBreeds),
        fail
      );
      expect(httpClientSpy.get.calls.count()).toBe(1, 'one call');
    });

    it('should return an empty array when the server returns an error', () => {
      const errorResponse = new HttpErrorResponse({
        error: 'test 404 error',
        status: 404,
        statusText: 'Not found'
      });

      httpClientSpy.get.and.returnValue(asyncError(errorResponse));

      service.searchBreeds("Test").subscribe(
        result => expect(result).toEqual([]),
        fail
      )
      expect(httpClientSpy.get.calls.count()).toBe(1, 'one call');
    });
  });

  describe('getImageUrl', () => {

    it('should return expected url array', () => {
      const expectedResult: string[] = ["Test"];

      httpClientSpy.get.and.returnValue(asyncData(expectedResult));

      service.getImageUrl("Test").subscribe(
        result => expect(result).toEqual(expectedResult),
        fail
      );
      expect(httpClientSpy.get.calls.count()).toBe(1, 'one call');
    });

    it('should return an empty array when the server returns an error', () => {
      const errorResponse = new HttpErrorResponse({
        error: 'test 404 error',
        status: 404,
        statusText: 'Not found'
      });

      httpClientSpy.get.and.returnValue(asyncError(errorResponse));

      service.getImageUrl("Test").subscribe(
        result => expect(result).toEqual([]),
        fail
      )
      expect(httpClientSpy.get.calls.count()).toBe(1, 'one call');
    });
  });
});

export function asyncError<T>(errorObject: T) {
    return defer(() => Promise.reject(errorObject));
  }
  
  export function asyncData<T>(data: T) {
    return defer(() => Promise.resolve(data));
  }