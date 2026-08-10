| Description                                      | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · Keccak-384 · BouncyCastle       | 128B         |     326.0 ns |   3.96 ns |   3.31 ns |         - |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar | 128B         |     447.2 ns |   3.54 ns |   2.77 ns |         - |
|                                                  |              |              |           |           |           |
| TryComputeHash · Keccak-384 · BouncyCastle       | 137B         |     331.5 ns |   1.77 ns |   1.48 ns |         - |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar | 137B         |     437.5 ns |   3.44 ns |   2.88 ns |         - |
|                                                  |              |              |           |           |           |
| TryComputeHash · Keccak-384 · BouncyCastle       | 1KB          |   1,556.5 ns |   5.00 ns |   4.43 ns |         - |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar | 1KB          |   1,624.6 ns |   2.53 ns |   2.24 ns |         - |
|                                                  |              |              |           |           |           |
| TryComputeHash · Keccak-384 · BouncyCastle       | 1025B        |   1,559.3 ns |   8.01 ns |   7.50 ns |         - |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar | 1025B        |   1,625.1 ns |   1.52 ns |   1.19 ns |         - |
|                                                  |              |              |           |           |           |
| TryComputeHash · Keccak-384 · BouncyCastle       | 8KB          |  12,160.5 ns | 113.10 ns | 105.80 ns |         - |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar | 8KB          |  12,550.3 ns |  16.53 ns |  15.46 ns |         - |
|                                                  |              |              |           |           |           |
| TryComputeHash · Keccak-384 · BouncyCastle       | 128KB        | 193,521.9 ns | 472.27 ns | 441.76 ns |         - |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar | 128KB        | 199,780.6 ns | 479.93 ns | 448.92 ns |         - |