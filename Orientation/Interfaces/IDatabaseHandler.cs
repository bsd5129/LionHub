using System;
using SQLite.Net;
namespace Orientation {
  public interface IDatabaseHandler {
    SQLiteConnection getDBConnection();
  }
}

