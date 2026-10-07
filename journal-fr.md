# Journal — Mercredi 7 octobre 2026 (Jour 1)

## 1. Types valeur et types référence

| | Type valeur | Type référence |
|---|---|---|
| Exemples | `int`, `double`, `decimal`, `bool`, `enum`, `struct` | `class`, `string`, `List<T>`, `record` |
| La variable contient… | la valeur elle-même | une adresse (référence) vers un objet |
| `b = a` copie… | la valeur → deux copies indépendantes | l'adresse → les deux variables pointent vers le même objet |
| Peut être `null` ? | Non (sauf `int?`) | Oui |

- `string` est un type référence, mais il est **immuable** : `s = s + "!"` crée une nouvelle chaîne.

➕ **Passage de paramètres :** en C#, les paramètres sont passés **par valeur** par défaut.
Pour un `struct`, la méthode reçoit une copie de la valeur ; pour une `class`, elle reçoit une copie de l'adresse, donc elle modifie le même objet.

## 2. struct, class et record

- `struct` : type valeur.
- `class` : type référence. `==` compare les **adresses** (est-ce le même objet ?).
- `record` : type référence fait pour transporter des données. `==` compare les **valeurs**.
  `with` crée une copie modifiée (`r2 = r1 with { Age = 30 }`), et `ToString()` est généré automatiquement.

## 3. ➕ Interfaces et injection de dépendances

- Une interface est un **contrat** : elle dit *quoi* faire, pas *comment*.
- `TicketsController` dépend de `ITicketService` et non de `TicketService`, pour pouvoir :
  1. tester le contrôleur avec un faux service ;
  2. changer l'implémentation sans modifier le contrôleur ;
  3. laisser ASP.NET Core créer l'objet (injection de dépendances).
- `builder.Services.AddScoped<ITicketService, TicketService>();`
  → « quand on demande un `ITicketService`, crée un `TicketService` ». `Scoped` = un objet par requête HTTP.

## 4. Application sur les modèles de SupportFlow

- `Ticket` : `Id` (valeur), `Title` (référence), `Status` et `Priority` (enum → valeur), `User`, `Category`, `Comments` (référence).
- `User` : `Id`, `Name`, `Email`, `Password`, `Role` (enum), `Tickets` (liste).
- `Category` : `Id`, `Name`, `Tickets` (liste).
- **Relations un-à-plusieurs :** `User 1 ── * Ticket * ── 1 Category`.
- ➕ EF Core crée automatiquement les colonnes `UserId` et `CategoryId` (*propriétés fantômes*).

## 5. Le rôle des DTO

Le DTO contrôle exactement ce que le monde extérieur peut **voir** ou **envoyer**. Trois raisons :
1. **Protéger contre la sur-affectation (over-posting)** : le client ne peut pas envoyer `Id` ou `Status`.
2. **Éviter les boucles infinies dans le JSON** (références circulaires : Ticket → User → Tickets → …).
3. **Séparer l'API de la base de données** : on peut changer le modèle sans casser les clients.

Exemples : le créateur du ticket vient de l'**ID utilisateur dans le JWT** ; le statut initial (`Open`) est décidé par le **serveur**.

## 6. Améliorations SupportFlow à faire
- [ ] Renommer `Password` en `PasswordHash`
- [ ] Ajouter `CreatedAt` à `Ticket`
- [ ] Déclarer `UserId` et `CategoryId` explicitement

## 7. Recherche d'emploi
- Tracker créé : 23 offres .NET vérifiées (5 priorité A).
- Constat : la plupart des offres demandent Bac+5 et 3 ans → il faut un portfolio solide et du contact direct.