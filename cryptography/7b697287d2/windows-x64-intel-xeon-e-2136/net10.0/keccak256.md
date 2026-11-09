| Description                                      | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|----------:|
| TryComputeHash · Keccak-256 · CryptoHives-Scalar | 128B         |     325.3 ns |     6.48 ns |     6.06 ns |   5,476 B |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX2   | 128B         |     411.6 ns |     6.26 ns |     5.86 ns |   5,249 B |         - |
| TryComputeHash · Keccak-256 · BouncyCastle       | 128B         |     458.8 ns |     8.00 ns |     7.48 ns |   6,303 B |         - |
|                                                  |              |              |             |             |           |           |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar | 137B         |     633.8 ns |     9.60 ns |     8.98 ns |   5,456 B |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX2   | 137B         |     809.8 ns |    10.65 ns |     9.96 ns |   5,229 B |         - |
| TryComputeHash · Keccak-256 · BouncyCastle       | 137B         |     867.3 ns |    13.42 ns |    12.56 ns |   7,691 B |         - |
|                                                  |              |              |             |             |           |           |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar | 1KB          |   2,536.2 ns |    23.57 ns |    22.05 ns |   5,485 B |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX2   | 1KB          |   3,219.7 ns |    17.18 ns |    16.07 ns |   5,237 B |         - |
| TryComputeHash · Keccak-256 · BouncyCastle       | 1KB          |   3,409.1 ns |    43.29 ns |    40.49 ns |   7,674 B |         - |
|                                                  |              |              |             |             |           |           |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar | 1025B        |   2,522.6 ns |    38.16 ns |    35.69 ns |   5,464 B |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX2   | 1025B        |   3,202.1 ns |    40.93 ns |    38.29 ns |   5,237 B |         - |
| TryComputeHash · Keccak-256 · BouncyCastle       | 1025B        |   3,412.7 ns |    37.96 ns |    35.51 ns |   7,674 B |         - |
|                                                  |              |              |             |             |           |           |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar | 8KB          |  18,737.7 ns |   306.87 ns |   287.05 ns |   5,460 B |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX2   | 8KB          |  24,166.3 ns |   316.19 ns |   295.77 ns |   5,231 B |         - |
| TryComputeHash · Keccak-256 · BouncyCastle       | 8KB          |  25,626.7 ns |   393.39 ns |   367.98 ns |   7,670 B |         - |
|                                                  |              |              |             |             |           |           |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar | 128KB        | 295,564.4 ns | 4,501.01 ns | 4,210.25 ns |   5,462 B |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX2   | 128KB        | 381,394.3 ns | 5,728.48 ns | 5,358.43 ns |   5,235 B |         - |
| TryComputeHash · Keccak-256 · BouncyCastle       | 128KB        | 404,723.4 ns | 5,177.30 ns | 4,842.85 ns |   7,704 B |         - |