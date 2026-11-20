| Description                                      | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|----------:|
| TryComputeHash · Keccak-512 · CryptoHives-Scalar | 128B         |     821.4 ns |     1.03 ns |     0.97 ns |   9,814 B |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX2   | 128B         |   1,054.9 ns |     4.29 ns |     3.80 ns |  15,909 B |         - |
| TryComputeHash · Keccak-512 · BouncyCastle       | 128B         |   1,141.2 ns |     1.28 ns |     1.14 ns |  16,819 B |         - |
|                                                  |              |              |             |             |           |           |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar | 137B         |     820.5 ns |     0.62 ns |     0.51 ns |  16,149 B |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX2   | 137B         |   1,104.4 ns |     3.97 ns |     3.71 ns |  15,909 B |         - |
| TryComputeHash · Keccak-512 · BouncyCastle       | 137B         |   1,143.1 ns |     1.23 ns |     1.09 ns |  16,629 B |         - |
|                                                  |              |              |             |             |           |           |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar | 1KB          |   6,040.1 ns |     4.33 ns |     4.05 ns |   9,821 B |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX2   | 1KB          |   7,842.5 ns |    35.22 ns |    32.95 ns |  15,916 B |         - |
| TryComputeHash · Keccak-512 · BouncyCastle       | 1KB          |   8,261.8 ns |    16.79 ns |    14.89 ns |  16,590 B |         - |
|                                                  |              |              |             |             |           |           |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar | 1025B        |   6,051.1 ns |     2.24 ns |     1.87 ns |  16,165 B |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX2   | 1025B        |   7,811.9 ns |    21.17 ns |    19.80 ns |  15,916 B |         - |
| TryComputeHash · Keccak-512 · BouncyCastle       | 1025B        |   8,209.5 ns |    14.91 ns |    13.95 ns |  16,590 B |         - |
|                                                  |              |              |             |             |           |           |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar | 8KB          |  45,285.9 ns |    31.56 ns |    27.97 ns |  16,156 B |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX2   | 8KB          |  58,132.3 ns |   228.14 ns |   213.40 ns |   9,590 B |         - |
| TryComputeHash · Keccak-512 · BouncyCastle       | 8KB          |  62,112.0 ns |    49.40 ns |    46.20 ns |  10,290 B |         - |
|                                                  |              |              |             |             |           |           |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar | 128KB        | 723,078.2 ns |   422.46 ns |   374.50 ns |  16,171 B |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX2   | 128KB        | 982,628.4 ns | 2,299.34 ns | 2,150.80 ns |  16,119 B |         - |
| TryComputeHash · Keccak-512 · BouncyCastle       | 128KB        | 991,007.6 ns |   414.36 ns |   346.01 ns |  16,662 B |         - |