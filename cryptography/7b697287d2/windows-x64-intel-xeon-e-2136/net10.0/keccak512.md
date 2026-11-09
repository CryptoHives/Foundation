| Description                                      | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|----------:|
| TryComputeHash · Keccak-512 · CryptoHives-Scalar | 128B         |     623.8 ns |     9.77 ns |     9.14 ns |   5,456 B |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX2   | 128B         |     794.5 ns |    10.99 ns |    10.28 ns |   5,229 B |         - |
| TryComputeHash · Keccak-512 · BouncyCastle       | 128B         |     875.8 ns |    10.91 ns |    10.21 ns |   7,707 B |         - |
|                                                  |              |              |             |             |           |           |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar | 137B         |     629.1 ns |     6.61 ns |     6.18 ns |   5,457 B |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX2   | 137B         |     798.2 ns |    13.55 ns |    12.67 ns |   5,230 B |         - |
| TryComputeHash · Keccak-512 · BouncyCastle       | 137B         |     872.6 ns |    12.57 ns |    11.76 ns |   7,729 B |         - |
|                                                  |              |              |             |             |           |           |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar | 1KB          |   4,619.5 ns |    67.66 ns |    63.29 ns |   5,456 B |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX2   | 1KB          |   5,914.5 ns |    60.72 ns |    56.79 ns |   5,229 B |         - |
| TryComputeHash · Keccak-512 · BouncyCastle       | 1KB          |   6,271.9 ns |    98.74 ns |    92.36 ns |   7,647 B |         - |
|                                                  |              |              |             |             |           |           |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar | 1025B        |   4,606.7 ns |    73.74 ns |    68.98 ns |   5,458 B |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX2   | 1025B        |   5,934.5 ns |   100.79 ns |    94.27 ns |   5,231 B |         - |
| TryComputeHash · Keccak-512 · BouncyCastle       | 1025B        |   6,277.7 ns |    93.00 ns |    86.99 ns |   7,666 B |         - |
|                                                  |              |              |             |             |           |           |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar | 8KB          |  34,689.3 ns |   566.67 ns |   530.06 ns |   5,456 B |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX2   | 8KB          |  44,524.1 ns |   853.08 ns |   837.84 ns |   5,229 B |         - |
| TryComputeHash · Keccak-512 · BouncyCastle       | 8KB          |  46,070.1 ns |   131.67 ns |   102.80 ns |   7,704 B |         - |
|                                                  |              |              |             |             |           |           |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar | 128KB        | 536,306.0 ns | 1,606.46 ns | 1,502.68 ns |   5,467 B |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX2   | 128KB        | 692,584.2 ns | 1,252.79 ns | 1,110.57 ns |   5,240 B |         - |
| TryComputeHash · Keccak-512 · BouncyCastle       | 128KB        | 733,252.6 ns | 1,373.31 ns | 1,284.60 ns |   7,722 B |         - |