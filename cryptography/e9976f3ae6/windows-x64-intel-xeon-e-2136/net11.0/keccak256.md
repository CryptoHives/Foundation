| Description                                      | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|----------:|
| TryComputeHash · Keccak-256 · CryptoHives-Scalar | 128B         |     430.6 ns |     1.04 ns |     0.97 ns |  16,160 B |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX2   | 128B         |     559.0 ns |     1.65 ns |     1.54 ns |   9,585 B |         - |
| TryComputeHash · Keccak-256 · BouncyCastle       | 128B         |     605.8 ns |     2.25 ns |     2.11 ns |   8,819 B |         - |
|                                                  |              |              |             |             |           |           |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar | 137B         |     829.8 ns |     0.92 ns |     0.86 ns |   9,814 B |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX2   | 137B         |   1,055.2 ns |     3.28 ns |     3.07 ns |   9,574 B |         - |
| TryComputeHash · Keccak-256 · BouncyCastle       | 137B         |   1,133.0 ns |     1.48 ns |     1.39 ns |  10,216 B |         - |
|                                                  |              |              |             |             |           |           |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar | 1KB          |   3,305.2 ns |     2.77 ns |     2.59 ns |   9,821 B |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX2   | 1KB          |   4,368.0 ns |     7.42 ns |     6.94 ns |   9,581 B |         - |
| TryComputeHash · Keccak-256 · BouncyCastle       | 1KB          |   4,444.8 ns |     4.04 ns |     3.37 ns |  16,514 B |         - |
|                                                  |              |              |             |             |           |           |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar | 1025B        |   3,307.4 ns |    10.59 ns |     9.91 ns |  16,156 B |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX2   | 1025B        |   4,161.3 ns |     4.04 ns |     3.58 ns |  15,916 B |         - |
| TryComputeHash · Keccak-256 · BouncyCastle       | 1025B        |   4,448.6 ns |     9.33 ns |     8.73 ns |  16,704 B |         - |
|                                                  |              |              |             |             |           |           |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar | 8KB          |  24,779.2 ns |    83.59 ns |    78.19 ns |  16,156 B |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX2   | 8KB          |  31,508.4 ns |    85.80 ns |    80.26 ns |  15,916 B |         - |
| TryComputeHash · Keccak-256 · BouncyCastle       | 8KB          |  33,571.0 ns |    61.82 ns |    54.80 ns |  16,506 B |         - |
|                                                  |              |              |             |             |           |           |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar | 128KB        | 387,890.3 ns |   733.03 ns |   612.11 ns |   9,830 B |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX2   | 128KB        | 497,790.7 ns | 2,075.40 ns | 1,941.33 ns |   9,581 B |         - |
| TryComputeHash · Keccak-256 · BouncyCastle       | 128KB        | 530,872.6 ns | 1,099.14 ns | 1,028.13 ns |  10,190 B |         - |