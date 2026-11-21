| Description                                      | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|----------:|
| TryComputeHash · Keccak-384 · CryptoHives-Scalar | 128B         |     824.8 ns |     2.09 ns |     1.85 ns |  16,348 B |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX2   | 128B         |   1,057.5 ns |     2.48 ns |     2.07 ns |   9,574 B |         - |
| TryComputeHash · Keccak-384 · BouncyCastle       | 128B         |   1,135.4 ns |     0.71 ns |     0.60 ns |  16,688 B |         - |
|                                                  |              |              |             |             |           |           |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar | 137B         |     828.8 ns |     2.95 ns |     2.76 ns |  16,149 B |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX2   | 137B         |   1,051.2 ns |     1.71 ns |     1.43 ns |  15,918 B |         - |
| TryComputeHash · Keccak-384 · BouncyCastle       | 137B         |   1,135.6 ns |     1.13 ns |     1.00 ns |  10,163 B |         - |
|                                                  |              |              |             |             |           |           |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar | 1KB          |   4,095.2 ns |    11.83 ns |    11.07 ns |  16,346 B |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX2   | 1KB          |   5,171.1 ns |     9.76 ns |     8.65 ns |  15,916 B |         - |
| TryComputeHash · Keccak-384 · BouncyCastle       | 1KB          |   5,529.1 ns |     4.47 ns |     4.18 ns |  16,394 B |         - |
|                                                  |              |              |             |             |           |           |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar | 1025B        |   4,080.4 ns |     9.09 ns |     8.50 ns |  16,156 B |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX2   | 1025B        |   5,161.2 ns |    13.02 ns |    11.54 ns |  15,916 B |         - |
| TryComputeHash · Keccak-384 · BouncyCastle       | 1025B        |   5,530.0 ns |     4.39 ns |     4.11 ns |  16,584 B |         - |
|                                                  |              |              |             |             |           |           |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar | 8KB          |  31,755.1 ns |    82.44 ns |    77.12 ns |   9,821 B |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX2   | 8KB          |  40,585.4 ns |    46.63 ns |    43.62 ns |   9,581 B |         - |
| TryComputeHash · Keccak-384 · BouncyCastle       | 8KB          |  43,308.5 ns |    32.76 ns |    29.04 ns |  16,431 B |         - |
|                                                  |              |              |             |             |           |           |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar | 128KB        | 504,498.5 ns |   962.71 ns |   853.42 ns |  16,178 B |         - |
| TryComputeHash · Keccak-384 · BouncyCastle       | 128KB        | 689,045.1 ns |   441.71 ns |   368.85 ns |  16,470 B |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX2   | 128KB        | 736,998.3 ns | 1,380.54 ns | 1,291.36 ns |  16,119 B |         - |