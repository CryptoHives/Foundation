| Description                                      | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · Keccak-512 · BouncyCastle       | 128B         |     327.5 ns |     5.48 ns |     4.86 ns |         - |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar | 128B         |     340.6 ns |     1.01 ns |     0.95 ns |         - |
|                                                  |              |              |             |             |           |
| TryComputeHash · Keccak-512 · BouncyCastle       | 137B         |     326.2 ns |     0.71 ns |     0.56 ns |         - |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar | 137B         |     327.7 ns |     0.53 ns |     0.49 ns |         - |
|                                                  |              |              |             |             |           |
| TryComputeHash · Keccak-512 · BouncyCastle       | 1KB          |   2,311.5 ns |     2.80 ns |     2.18 ns |         - |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar | 1KB          |   2,472.8 ns |     4.85 ns |     4.53 ns |         - |
|                                                  |              |              |             |             |           |
| TryComputeHash · Keccak-512 · BouncyCastle       | 1025B        |   2,300.4 ns |     7.16 ns |     6.35 ns |         - |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar | 1025B        |   2,476.5 ns |     6.99 ns |     5.46 ns |         - |
|                                                  |              |              |             |             |           |
| TryComputeHash · Keccak-512 · BouncyCastle       | 8KB          |  17,430.5 ns |    58.13 ns |    51.53 ns |         - |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar | 8KB          |  17,943.4 ns |    15.84 ns |    14.82 ns |         - |
|                                                  |              |              |             |             |           |
| TryComputeHash · Keccak-512 · BouncyCastle       | 128KB        | 278,051.6 ns | 2,124.22 ns | 1,987.00 ns |         - |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar | 128KB        | 286,319.3 ns |   491.01 ns |   435.26 ns |         - |