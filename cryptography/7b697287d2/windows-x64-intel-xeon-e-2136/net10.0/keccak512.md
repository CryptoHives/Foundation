| Description                                      | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|----------:|
| TryComputeHash · Keccak-512 · CryptoHives-Scalar | 128B         |     823.7 ns |     0.56 ns |     0.47 ns |   5,456 B |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX2   | 128B         |   1,045.1 ns |     1.52 ns |     1.42 ns |   5,229 B |         - |
| TryComputeHash · Keccak-512 · BouncyCastle       | 128B         |   1,144.0 ns |     1.44 ns |     1.34 ns |   7,712 B |         - |
|                                                  |              |              |             |             |           |           |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar | 137B         |     821.1 ns |     0.47 ns |     0.44 ns |   5,457 B |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX2   | 137B         |   1,047.4 ns |     1.36 ns |     1.27 ns |   5,235 B |         - |
| TryComputeHash · Keccak-512 · BouncyCastle       | 137B         |   1,148.3 ns |     1.22 ns |     1.14 ns |   7,689 B |         - |
|                                                  |              |              |             |             |           |           |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar | 1KB          |   6,045.6 ns |     5.51 ns |     4.88 ns |   5,456 B |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX2   | 1KB          |   7,735.8 ns |    21.20 ns |    19.83 ns |   5,229 B |         - |
| TryComputeHash · Keccak-512 · BouncyCastle       | 1KB          |   8,349.1 ns |    10.64 ns |     9.43 ns |   7,662 B |         - |
|                                                  |              |              |             |             |           |           |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar | 1025B        |   6,054.2 ns |     6.14 ns |     5.74 ns |   5,458 B |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX2   | 1025B        |   7,726.1 ns |    29.09 ns |    24.29 ns |   5,231 B |         - |
| TryComputeHash · Keccak-512 · BouncyCastle       | 1025B        |   8,250.0 ns |     5.83 ns |     5.17 ns |   7,666 B |         - |
|                                                  |              |              |             |             |           |           |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar | 8KB          |  45,392.4 ns |    35.51 ns |    33.21 ns |   5,456 B |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX2   | 8KB          |  58,624.4 ns |    72.50 ns |    67.82 ns |   5,229 B |         - |
| TryComputeHash · Keccak-512 · BouncyCastle       | 8KB          |  62,266.1 ns |    53.60 ns |    47.51 ns |   7,704 B |         - |
|                                                  |              |              |             |             |           |           |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar | 128KB        | 723,774.5 ns |   433.52 ns |   384.31 ns |   5,467 B |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX2   | 128KB        | 935,732.9 ns | 2,981.60 ns | 2,788.99 ns |   5,258 B |         - |
| TryComputeHash · Keccak-512 · BouncyCastle       | 128KB        | 993,550.9 ns |   702.52 ns |   622.77 ns |   7,722 B |         - |