| Description                                        | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|--------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 128B         |     573.0 ns |     0.90 ns |     0.80 ns |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 128B         |     781.7 ns |     1.08 ns |     0.90 ns |         - |
|                                                    |              |              |             |             |           |
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 137B         |     604.1 ns |     1.25 ns |     1.04 ns |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 137B         |     833.6 ns |     1.00 ns |     0.88 ns |         - |
|                                                    |              |              |             |             |           |
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 1KB          |   3,872.6 ns |     8.76 ns |     8.19 ns |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 1KB          |   5,056.3 ns |    10.10 ns |     8.43 ns |         - |
|                                                    |              |              |             |             |           |
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 1025B        |   3,702.0 ns |     4.54 ns |     4.02 ns |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 1025B        |   5,054.0 ns |     6.83 ns |     6.05 ns |         - |
|                                                    |              |              |             |             |           |
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 8KB          |  28,761.2 ns |    75.95 ns |    67.33 ns |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 8KB          |  39,094.7 ns |    43.53 ns |    36.35 ns |         - |
|                                                    |              |              |             |             |           |
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 128KB        | 458,396.9 ns | 1,973.47 ns | 1,647.93 ns |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 128KB        | 625,589.9 ns | 1,111.66 ns |   928.29 ns |         - |