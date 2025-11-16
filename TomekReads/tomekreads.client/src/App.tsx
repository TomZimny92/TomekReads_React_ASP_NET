import { useState, useEffect } from 'react'
//import reactLogo from './assets/react.svg'
//import viteLogo from '/vite.svg'
import './App.css'
import BookView from './components/BookView';
import type { Book } from './types/Book';

function App() {
    const [books, setBooks] = useState(null);
    // https://localhost:7085

    useEffect(() => {
        fetch('https://localhost:7085/api/GetAllBooksAsync')
            .then(response => response.json())
            .then(json => setBooks(json))
            .catch(error => console.error(error));
    }, []);




    //function loadBooks() {
    //    const xhr = new XMLHttpRequest();
    //    xhr.open('GET', 'https://localhost:7085/api/GetAllBooksAsync');
    //    xhr.onload = function () {
    //        if (xhr.status === 200) {
    //            setBooks(JSON.parse(xhr.responseText));
    //        }
    //    };
    //    xhr.send();
    //}


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
//function LoadBooks(): void {
    
//}

export default App
