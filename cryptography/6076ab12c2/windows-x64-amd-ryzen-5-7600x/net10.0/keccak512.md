| Description                                       | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|-------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|----------:|
| TryComputeHash · Keccak-512 · CryptoHives-Scalar  | 128B         |     461.4 ns |     0.54 ns |     0.45 ns |   5,433 B |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX2    | 128B         |     606.0 ns |     0.34 ns |     0.30 ns |   4,942 B |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX512F | 128B         |     632.8 ns |     0.70 ns |     0.66 ns |   3,937 B |         - |
| TryComputeHash · Keccak-512 · BouncyCastle        | 128B         |     719.0 ns |     1.30 ns |     1.16 ns |   7,656 B |         - |
|                                                   |              |              |             |             |           |           |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar  | 137B         |     460.8 ns |     0.49 ns |     0.44 ns |   5,434 B |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX2    | 137B         |     607.4 ns |     0.29 ns |     0.27 ns |   4,943 B |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX512F | 137B         |     629.0 ns |     0.38 ns |     0.35 ns |   3,938 B |         - |
| TryComputeHash · Keccak-512 · BouncyCastle        | 137B         |     718.9 ns |     1.42 ns |     1.26 ns |   7,659 B |         - |
|                                                   |              |              |             |             |           |           |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar  | 1KB          |   3,393.8 ns |     7.84 ns |     7.34 ns |   5,436 B |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX2    | 1KB          |   4,483.7 ns |    41.21 ns |    36.53 ns |   4,945 B |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX512F | 1KB          |   4,622.5 ns |     4.15 ns |     3.88 ns |   3,940 B |         - |
| TryComputeHash · Keccak-512 · BouncyCastle        | 1KB          |   5,271.6 ns |    14.28 ns |    13.36 ns |   7,623 B |         - |
|                                                   |              |              |             |             |           |           |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar  | 1025B        |   3,386.7 ns |     6.70 ns |     5.94 ns |   5,438 B |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX2    | 1025B        |   4,465.6 ns |     1.94 ns |     1.82 ns |   4,947 B |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX512F | 1025B        |   4,605.5 ns |     2.19 ns |     2.04 ns |   3,942 B |         - |
| TryComputeHash · Keccak-512 · BouncyCastle        | 1025B        |   5,260.3 ns |    11.11 ns |    10.40 ns |   7,625 B |         - |
|                                                   |              |              |             |             |           |           |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar  | 8KB          |  25,710.3 ns |    62.19 ns |    58.17 ns |   5,436 B |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX2    | 8KB          |  33,788.7 ns |    11.03 ns |     9.78 ns |   4,945 B |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX512F | 8KB          |  34,895.8 ns |    21.32 ns |    19.95 ns |   3,940 B |         - |
| TryComputeHash · Keccak-512 · BouncyCastle        | 8KB          |  39,794.5 ns |    72.78 ns |    68.08 ns |   7,625 B |         - |
|                                                   |              |              |             |             |           |           |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar  | 128KB        | 409,649.2 ns |   894.30 ns |   836.53 ns |   5,447 B |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX2    | 128KB        | 539,440.7 ns |   431.27 ns |   403.41 ns |   4,956 B |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX512F | 128KB        | 557,648.8 ns |   270.26 ns |   252.80 ns |   3,951 B |         - |
| TryComputeHash · Keccak-512 · BouncyCastle        | 128KB        | 630,218.8 ns | 1,223.39 ns | 1,144.36 ns |   7,635 B |         - |