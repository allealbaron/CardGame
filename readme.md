<p>This solution describes a set of classes representing a deck of cards, such us the cards used in Poker (with the French Card) or the cards used in Brisca (Spanish cards).
</p>

<p>Two operators must be provided:</p>

<li> 
    <ul>
        Shuffle: Does not return a value, but it should permute the deck.
    </ul>
    <ul>
        DealOneCard: It should return a card from the card.
    </ul>
</li>

<p>The problem was designed for poker cards, but it was extended to Spanish cards. Any user could use other kind of deck, for example, a deck for playing Continental (using two decks of french cards), a deck for playing Dobble...</p>

The application has been designed using Dependency Injection, making easy to configure the application for another decks and games.

These are the interfaces created for the application:
<li>
    <ul>
        <b>ICard:</b>
        Represents a single card. Classes implementing this interface shall also implement interfaces IComparable and IEquatable, to help sorting and comparing elements.
    </ul>
    <ul>
        <b>IDeck:</b>
        Represents a deck, containting a List of ICards. This deck has these methods:
            <ul>
                <li>
                    <b>Shuffle</b>:
                    Shuffles the deck using the IShuffler provided. It does not return a value.
                </li>
                <li>
                    <b>DealOneCard</b>:
                    Deals a ICard. The method used to extract the ICard is implemented in the IDealer object provided.
                </li>
                <li>
                    <b>GenerateCardDeck</b>:
                    Generates a new deck as a IList of ICard. This IList is sorted.
                </li>
                <li>
                    <b>NumberOfCardsEntireDeck</b>:
                    Returns the number of ICard a brand new deck shall have.
                </li>
                <li>
                    <b>IsEmptyDeck</b>:
                    Returns if the list of ICard contained
                    in the deck is empty.
                </li>
            </ul>
        </ul>
    <ul>
        <b>IShuffler:</b>
        Interface for shuffling decks. A regular shuffler deck method is implemented in this solution, but maybe the company would like to use  other shuffling methods. The interface has only one method, that takes a IList o ICards and returns it in another order.
    </ul>
    <ul>
        <b>IDealer:</b>
        Similar to IShuffler, returns the index of the ICard the system shall return when DealOneCard is called. In the regular dealer class provided, system returns the first ICard found in the deck, but for another games the system could return the third or the last ICard.
    </ul>
</li>

<p>The solution also contains a test project, that checks all the methods created for this application. Enjoy!</p>