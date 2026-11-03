| Description                                       | TestDataSize | Mean         | Error       | StdDev    | Code Size | Allocated |
|-------------------------------------------------- |------------- |-------------:|------------:|----------:|----------:|----------:|
| TryComputeHash · Keccak-512 · CryptoHives-Scalar  | 128B         |     460.8 ns |     0.54 ns |   0.42 ns |   5,433 B |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX2    | 128B         |     606.2 ns |     0.25 ns |   0.24 ns |   4,924 B |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX512F | 128B         |     630.1 ns |     0.46 ns |   0.36 ns |   3,937 B |         - |
| TryComputeHash · Keccak-512 · BouncyCastle        | 128B         |     720.3 ns |     1.07 ns |   1.00 ns |   7,665 B |         - |
|                                                   |              |              |             |           |           |           |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar  | 137B         |     460.7 ns |     0.42 ns |   0.39 ns |   5,439 B |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX2    | 137B         |     607.0 ns |     0.26 ns |   0.25 ns |   4,925 B |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX512F | 137B         |     630.1 ns |     0.35 ns |   0.33 ns |   3,943 B |         - |
| TryComputeHash · Keccak-512 · BouncyCastle        | 137B         |     721.7 ns |     1.48 ns |   1.38 ns |   7,603 B |         - |
|                                                   |              |              |             |           |           |           |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar  | 1KB          |   3,381.6 ns |     6.14 ns |   5.45 ns |   5,436 B |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX2    | 1KB          |   4,468.9 ns |     2.08 ns |   1.95 ns |   4,927 B |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX512F | 1KB          |   4,597.4 ns |     1.66 ns |   1.55 ns |   3,940 B |         - |
| TryComputeHash · Keccak-512 · BouncyCastle        | 1KB          |   5,227.7 ns |    10.32 ns |   9.65 ns |   7,661 B |         - |
|                                                   |              |              |             |           |           |           |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar  | 1025B        |   3,381.0 ns |     3.92 ns |   3.67 ns |   5,438 B |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX2    | 1025B        |   4,472.0 ns |     2.50 ns |   2.34 ns |   4,929 B |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX512F | 1025B        |   4,598.9 ns |     2.03 ns |   1.80 ns |   3,942 B |         - |
| TryComputeHash · Keccak-512 · BouncyCastle        | 1025B        |   5,275.5 ns |     9.30 ns |   8.70 ns |   7,627 B |         - |
|                                                   |              |              |             |           |           |           |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar  | 8KB          |  25,616.8 ns |    19.06 ns |  15.91 ns |   5,436 B |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX2    | 8KB          |  33,892.1 ns |     9.24 ns |   8.64 ns |   4,927 B |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX512F | 8KB          |  34,805.0 ns |    12.68 ns |  10.59 ns |   3,940 B |         - |
| TryComputeHash · Keccak-512 · BouncyCastle        | 8KB          |  39,612.2 ns |    74.26 ns |  69.46 ns |   7,625 B |         - |
|                                                   |              |              |             |           |           |           |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar  | 128KB        | 409,372.9 ns | 1,095.03 ns | 970.72 ns |   5,447 B |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX2    | 128KB        | 540,557.8 ns |   257.45 ns | 228.22 ns |   4,938 B |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX512F | 128KB        | 557,104.9 ns |   197.10 ns | 174.73 ns |   3,951 B |         - |
| TryComputeHash · Keccak-512 · BouncyCastle        | 128KB        | 634,739.7 ns |   966.42 ns | 903.99 ns |   7,635 B |         - |