# ProjektSklep
Aplikacja do zarządzania zadaniami w firmie

Aby uruchomić aplikację niezbędne będzie posiadanie:

- Visual Studio 2022
- SQL SERVER

Następnie trzeba ustawić odpowiednie ConnectionString’i w pliku appsettings.json.

Wykonanie polecenia upadate-database zaktualizuje odpowiednio bazę danych bez tego aplikacja nie będzie działać prawidłowo.

Aplikacja jest w wykonana w wersji .Net 6.

Opis funkcji aplikacji
Po włączeniu aplikacji na pierwszym planie pojawi się formularz logowania. możemy się tutaj zalogować lub wybrać opcję dostępu jako gość.
Na pasku nawigacyjnym mamy 2 przyciski po lewej: odnośnik home do powrotu na początek aplikacji oraz listę dostępnych produktów. 
Po prawej stronie paska mamy dostęp do rejestracji oraz logowania użytkowników (po zalogowaniu pojawia się przycisk "wyloguj" który wyloguje bierzącego uzytkownika".
Po zalogowaniu się na odpowiednie konto z uprawnieniami (Login: admin, Hasło: admin) będą dostępne inne akcję:

W aplikacji są dwa rodzaje uprawnień:

- normal -> posiada okrojoną wersję aplikacji
- admin -> posiada dostęp do wszystkich funkcjonalności

 
