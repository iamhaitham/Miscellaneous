import { 
  AfterViewInit,
  ChangeDetectionStrategy, 
  Component,
  OnDestroy 
} from '@angular/core';
import { 
  Subscription, 
  BehaviorSubject, 
  fromEvent
} from 'rxjs';
import { 
  filter, 
  map, 
  tap
} from 'rxjs/operators';
import { 
  AllowedSpecialCharacter, 
  CharacterColor, 
  CharacterType 
} from './helpers';
import { TypingSpeedTestSerice } from './services';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
  changeDetection: ChangeDetectionStrategy.Default
})
export class AppComponent implements AfterViewInit, OnDestroy {
  private realText = 'Hello World';
  private insertedText = '';
  private insertedText$: BehaviorSubject<string> = new BehaviorSubject<string>(this.insertedText);
  private displayedCharacters: CharacterType[] = [];
  private subscription: Subscription;
  displayedCharacters$: BehaviorSubject<CharacterType[]> = new BehaviorSubject<CharacterType[]>([]);

  constructor(private readonly typingSpeedTestSerice: TypingSpeedTestSerice) {
    this.initializeDisplayedCharacters();
  }

  ngAfterViewInit(): void {
    this.subscription = fromEvent(document, 'keydown')
      .pipe(
        filter((keyboardEvent: KeyboardEvent) => this.typingSpeedTestSerice.getKeysToRecord(keyboardEvent)),
        map((keyboardEvent: KeyboardEvent) => keyboardEvent.key),
        tap((key: string) => {
          if (key === AllowedSpecialCharacter.Backspace) 
            this.insertedText = this.insertedText.slice(0, this.insertedText.length - 1);
          else if (this.insertedText.length < this.displayedCharacters.length)
            this.insertedText = [...this.insertedText, key].join('');

          this.insertedText$.next(this.insertedText);

          this.updateCharacterColor(key);
        })
      )
      .subscribe();
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }

  private initializeDisplayedCharacters(): void {
    [...this.realText].forEach((char: string, index: number) => {
      const valueToSet: CharacterType = {
        index,
        char,
        colorClass: CharacterColor.Black
      };

      this.displayedCharacters = [...this.displayedCharacters, valueToSet];
      this.displayedCharacters$.next(this.displayedCharacters);
    });
  }

  private updateCharacterColor(key: string): void {
    const lastInsertedCharacterIndex = this.insertedText.length - 1;
    const displayedCharacterAtLastInsertionIndex = this.getDisplayedCharacterAtGivenIndex(lastInsertedCharacterIndex);
    const displayedCharacterAfterCurrentCharacter = this.getDisplayedCharacterAtGivenIndex(lastInsertedCharacterIndex + 1);

    if (key === AllowedSpecialCharacter.Backspace)
      displayedCharacterAfterCurrentCharacter.colorClass = CharacterColor.Black;
    else if (displayedCharacterAtLastInsertionIndex)
      displayedCharacterAtLastInsertionIndex.colorClass = this.determineCharacterColor(displayedCharacterAtLastInsertionIndex);
  }

  private getDisplayedCharacterAtGivenIndex(givenIndex: number): CharacterType {
    return this.displayedCharacters.find(({ index }: CharacterType) => index === givenIndex);
  }

  private determineCharacterColor(characterAtGivenIndex: CharacterType): CharacterColor {
    const { index, char } = characterAtGivenIndex;

    return char === this.insertedText[index] ?
      CharacterColor.Green : 
      CharacterColor.Red;
  }
}
