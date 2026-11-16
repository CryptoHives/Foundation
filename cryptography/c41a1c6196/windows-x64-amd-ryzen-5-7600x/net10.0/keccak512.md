| Description                                       | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|-------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|----------:|
| TryComputeHash · Keccak-512 · CryptoHives-Scalar  | 128B         |     461.9 ns |     0.83 ns |     0.74 ns |   5,433 B |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX2    | 128B         |     608.2 ns |     0.53 ns |     0.47 ns |   4,924 B |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX512F | 128B         |     632.6 ns |     0.66 ns |     0.59 ns |   3,937 B |         - |
| TryComputeHash · Keccak-512 · BouncyCastle        | 128B         |     719.3 ns |     1.86 ns |     1.65 ns |   7,676 B |         - |
|                                                   |              |              |             |             |           |           |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar  | 137B         |     464.3 ns |     1.53 ns |     1.28 ns |   5,438 B |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX512F | 137B         |     630.0 ns |     0.87 ns |     0.82 ns |   3,942 B |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX2    | 137B         |     672.4 ns |     0.72 ns |     0.67 ns |   4,930 B |         - |
| TryComputeHash · Keccak-512 · BouncyCastle        | 137B         |     723.1 ns |     1.06 ns |     0.94 ns |   7,616 B |         - |
|                                                   |              |              |             |             |           |           |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar  | 1KB          |   3,403.7 ns |    13.35 ns |    11.83 ns |   5,436 B |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX2    | 1KB          |   4,470.8 ns |     3.94 ns |     3.68 ns |   4,927 B |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX512F | 1KB          |   4,605.3 ns |     4.31 ns |     4.03 ns |   3,942 B |         - |
| TryComputeHash · Keccak-512 · BouncyCastle        | 1KB          |   5,352.1 ns |    12.50 ns |    10.44 ns |   7,627 B |         - |
|                                                   |              |              |             |             |           |           |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar  | 1025B        |   3,395.1 ns |    14.04 ns |    11.73 ns |   5,438 B |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX2    | 1025B        |   4,462.6 ns |     6.29 ns |     5.88 ns |   4,929 B |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX512F | 1025B        |   4,646.9 ns |     2.55 ns |     2.26 ns |   3,942 B |         - |
| TryComputeHash · Keccak-512 · BouncyCastle        | 1025B        |   5,259.1 ns |    12.17 ns |    10.79 ns |   7,627 B |         - |
|                                                   |              |              |             |             |           |           |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar  | 8KB          |  25,746.0 ns |    90.31 ns |    80.05 ns |   5,436 B |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX2    | 8KB          |  33,940.9 ns |    47.99 ns |    44.89 ns |   4,927 B |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX512F | 8KB          |  34,889.2 ns |    49.40 ns |    46.21 ns |   3,940 B |         - |
| TryComputeHash · Keccak-512 · BouncyCastle        | 8KB          |  39,385.6 ns |   140.07 ns |   131.02 ns |   7,625 B |         - |
|                                                   |              |              |             |             |           |           |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar  | 128KB        | 411,074.9 ns | 1,457.03 ns | 1,291.62 ns |   5,447 B |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX2    | 128KB        | 541,388.3 ns |   687.04 ns |   642.66 ns |   4,938 B |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX512F | 128KB        | 555,913.9 ns |   429.66 ns |   380.88 ns |   3,951 B |         - |
| TryComputeHash · Keccak-512 · BouncyCastle        | 128KB        | 632,698.5 ns | 2,802.23 ns | 2,621.21 ns |   7,635 B |         - |