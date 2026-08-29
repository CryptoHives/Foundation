| Description                                        | TestDataSize | Mean         | Error        | StdDev       | Allocated |
|--------------------------------------------------- |------------- |-------------:|-------------:|-------------:|----------:|
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 128B         |     660.3 ns |      2.13 ns |      1.66 ns |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 128B         |     924.4 ns |      2.94 ns |      2.45 ns |         - |
|                                                    |              |              |              |              |           |
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 137B         |     693.7 ns |     13.12 ns |     14.03 ns |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 137B         |     969.9 ns |      3.50 ns |      3.10 ns |         - |
|                                                    |              |              |              |              |           |
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 1KB          |   4,412.4 ns |     12.56 ns |     11.13 ns |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 1KB          |   6,047.8 ns |      4.81 ns |      4.01 ns |         - |
|                                                    |              |              |              |              |           |
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 1025B        |   4,347.3 ns |      3.24 ns |      2.71 ns |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 1025B        |   6,055.1 ns |     12.16 ns |     10.16 ns |         - |
|                                                    |              |              |              |              |           |
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 8KB          |  34,657.7 ns |    391.30 ns |    366.03 ns |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 8KB          |  47,158.5 ns |    119.81 ns |    106.21 ns |         - |
|                                                    |              |              |              |              |           |
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 128KB        | 548,035.3 ns | 10,188.02 ns | 10,005.99 ns |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 128KB        | 755,273.9 ns |  7,887.38 ns |  6,991.96 ns |         - |