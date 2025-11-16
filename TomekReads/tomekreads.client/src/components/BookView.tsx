
import type { Book } from '../types/Book';

interface bookProp {
    book: Book
}

//function BookView({title, author, rating, review}:bookProp) {
//  return (
//      <>
//          <div>{title}</div>
//          <div>{author}</div>
//          <div>{rating}</div>
//          <div>{review}</div>
//      </>
//  );
//}

function BookView({book}: bookProp) {
    return (
        <>
            <div>{book.Title}</div>
            <div>{book.Author}</div>
            <div>{book.Rating}</div>
            <div>{book.Review}</div>
        </>
    );
}

export default BookView;