
import type { Book } from '../types/Book';


function BookView({book}: Book) {
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