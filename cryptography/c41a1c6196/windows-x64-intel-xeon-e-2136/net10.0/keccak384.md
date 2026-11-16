| Description                                      | TestDataSize | Mean         | Error       | StdDev       | Median       | Code Size | Allocated |
|------------------------------------------------- |------------- |-------------:|------------:|-------------:|-------------:|----------:|----------:|
| TryComputeHash · Keccak-384 · CryptoHives-Scalar | 128B         |     826.5 ns |     0.79 ns |      1.48 ns |     826.2 ns |   5,458 B |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX2   | 128B         |   1,067.0 ns |     5.64 ns |     10.45 ns |   1,061.9 ns |   5,231 B |         - |
| TryComputeHash · Keccak-384 · BouncyCastle       | 128B         |   1,152.6 ns |     1.12 ns |      2.07 ns |   1,153.1 ns |   7,982 B |         - |
|                                                  |              |              |             |              |              |           |           |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar | 137B         |     825.9 ns |     0.84 ns |      1.57 ns |     825.7 ns |   5,458 B |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX2   | 137B         |   1,059.2 ns |     6.93 ns |     13.18 ns |   1,051.9 ns |   5,231 B |         - |
| TryComputeHash · Keccak-384 · BouncyCastle       | 137B         |   1,154.6 ns |     1.19 ns |      2.17 ns |   1,154.5 ns |   7,985 B |         - |
|                                                  |              |              |             |              |              |           |           |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar | 1KB          |   4,095.6 ns |     4.12 ns |      7.74 ns |   4,094.5 ns |   5,464 B |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX2   | 1KB          |   5,236.3 ns |    29.35 ns |     55.13 ns |   5,220.3 ns |   5,237 B |         - |
| TryComputeHash · Keccak-384 · BouncyCastle       | 1KB          |   5,630.4 ns |     3.93 ns |      7.38 ns |   5,629.8 ns |   7,973 B |         - |
|                                                  |              |              |             |              |              |           |           |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar | 1025B        |   4,093.0 ns |     2.37 ns |      4.21 ns |   4,092.6 ns |   5,464 B |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX2   | 1025B        |   5,195.1 ns |     8.97 ns |     17.06 ns |   5,193.8 ns |   5,237 B |         - |
| TryComputeHash · Keccak-384 · BouncyCastle       | 1025B        |   5,647.2 ns |     3.61 ns |      6.70 ns |   5,646.6 ns |   7,954 B |         - |
|                                                  |              |              |             |              |              |           |           |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar | 8KB          |  31,708.9 ns |    24.16 ns |     44.19 ns |  31,704.6 ns |   5,462 B |         - |
| TryComputeHash · Keccak-384 · BouncyCastle       | 8KB          |  44,057.3 ns |    65.37 ns |    121.16 ns |  44,000.4 ns |   7,963 B |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX2   | 8KB          |  45,509.4 ns | 3,371.92 ns |  6,415.44 ns |  41,114.6 ns |   5,251 B |         - |
|                                                  |              |              |             |              |              |           |           |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar | 128KB        | 505,049.6 ns |   684.84 ns |  1,252.27 ns | 504,740.4 ns |   5,469 B |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX2   | 128KB        | 669,527.0 ns | 7,574.22 ns | 14,226.21 ns | 669,402.5 ns |   5,242 B |         - |
| TryComputeHash · Keccak-384 · BouncyCastle       | 128KB        | 704,889.4 ns |   894.91 ns |  1,658.78 ns | 704,596.1 ns |   7,940 B |         - |