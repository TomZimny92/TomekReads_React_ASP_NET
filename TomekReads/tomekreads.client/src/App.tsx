import { useState, useEffect } from 'react'
import './App.css'
import BookView from './components/BookView';
import type { Book } from './types/Book';

function App() {
    const [books, setBooks] = useState<Book[]>([]);

    useEffect(() => {
        const bookData = async () => {
            try {
                const response = await fetch('https://localhost:7085/api/GetAllBooksAsync');
                // check if response is good
                const result: Book[] = await response.json();
                setBooks(result);
            }
            catch (err) {
                console.log((err as Error).message);
            }
        }
        bookData();
    }, [])

  return (
    <>
          <h3>Books!</h3>
          {books.map((book: Book) => {
              return <BookView book={book} />
          })}
    </>
  )
}

// onMount, get all existing books via api and put it in a list

// the add button will use a modal and api to create a new book
    // when typing a book in the modal, use 3rd party api to help with the search and autofill the relevant fields with retrieved data

// when a book is added, the new entry is added to the books list
// i don't want to run api if i don't have to

// the page is re-rendered with the new book at the top

// search bar to filter books list

export default App
