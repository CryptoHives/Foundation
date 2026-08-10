| Description                                        | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|--------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 128B         |     574.7 ns |     1.80 ns |     1.51 ns |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 128B         |     762.7 ns |     5.09 ns |     4.52 ns |         - |
|                                                    |              |              |             |             |           |
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 137B         |     598.9 ns |     2.75 ns |     2.57 ns |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 137B         |     810.7 ns |     2.62 ns |     2.33 ns |         - |
|                                                    |              |              |             |             |           |
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 1KB          |   3,666.2 ns |    12.96 ns |    10.82 ns |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 1KB          |   4,925.3 ns |    24.94 ns |    23.32 ns |         - |
|                                                    |              |              |             |             |           |
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 1025B        |   3,669.2 ns |    13.18 ns |    11.68 ns |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 1025B        |   4,903.2 ns |    15.95 ns |    14.13 ns |         - |
|                                                    |              |              |             |             |           |
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 8KB          |  28,420.5 ns |   145.69 ns |   129.15 ns |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 8KB          |  38,031.2 ns |   147.00 ns |   122.75 ns |         - |
|                                                    |              |              |             |             |           |
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 128KB        | 453,575.7 ns | 1,541.47 ns | 1,287.20 ns |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 128KB        | 610,509.3 ns | 4,523.18 ns | 4,009.68 ns |         - |