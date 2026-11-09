| Description                                      | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|----------:|
| TryComputeHash · Keccak-384 · CryptoHives-Scalar | 128B         |     632.1 ns |     9.13 ns |     8.54 ns |   5,458 B |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX2   | 128B         |     801.4 ns |    10.71 ns |    10.02 ns |   5,231 B |         - |
| TryComputeHash · Keccak-384 · BouncyCastle       | 128B         |     880.2 ns |     8.00 ns |     7.48 ns |   7,986 B |         - |
|                                                  |              |              |             |             |           |           |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar | 137B         |     627.6 ns |    11.17 ns |    10.45 ns |   5,458 B |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX2   | 137B         |     808.6 ns |    11.19 ns |    10.47 ns |   5,229 B |         - |
| TryComputeHash · Keccak-384 · BouncyCastle       | 137B         |     880.8 ns |    13.20 ns |    12.35 ns |   7,960 B |         - |
|                                                  |              |              |             |             |           |           |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar | 1KB          |   3,135.4 ns |    29.48 ns |    27.57 ns |   5,464 B |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX2   | 1KB          |   3,969.8 ns |    55.19 ns |    51.63 ns |   5,237 B |         - |
| TryComputeHash · Keccak-384 · BouncyCastle       | 1KB          |   4,297.7 ns |    55.27 ns |    51.70 ns |   7,975 B |         - |
|                                                  |              |              |             |             |           |           |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar | 1025B        |   3,123.5 ns |    44.77 ns |    41.88 ns |   5,464 B |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX2   | 1025B        |   3,977.7 ns |    53.16 ns |    49.73 ns |   5,237 B |         - |
| TryComputeHash · Keccak-384 · BouncyCastle       | 1025B        |   4,284.3 ns |    71.91 ns |    67.26 ns |   7,990 B |         - |
|                                                  |              |              |             |             |           |           |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar | 8KB          |  24,144.1 ns |   368.31 ns |   344.52 ns |   5,462 B |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX2   | 8KB          |  31,037.8 ns |   519.81 ns |   486.23 ns |   5,237 B |         - |
| TryComputeHash · Keccak-384 · BouncyCastle       | 8KB          |  33,537.1 ns |   497.34 ns |   465.21 ns |   7,963 B |         - |
|                                                  |              |              |             |             |           |           |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar | 128KB        | 384,407.4 ns | 4,905.17 ns | 4,588.30 ns |   5,469 B |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX2   | 128KB        | 497,054.6 ns | 6,098.26 ns | 5,704.32 ns |   5,242 B |         - |
| TryComputeHash · Keccak-384 · BouncyCastle       | 128KB        | 534,375.1 ns | 9,003.20 ns | 8,421.60 ns |   7,962 B |         - |