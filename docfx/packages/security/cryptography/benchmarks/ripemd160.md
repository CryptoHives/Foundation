| Description                                          | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|----------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| ComputeHash | RIPEMD-160 | RIPEMD-160 (BouncyCastle) | 128B         |     671.3 ns |     1.78 ns |     1.39 ns |      96 B |
| ComputeHash | RIPEMD-160 | RIPEMD-160 (Managed)      | 128B         |     973.9 ns |     9.28 ns |     8.68 ns |      96 B |
|                                                      |              |              |             |             |           |
| ComputeHash | RIPEMD-160 | RIPEMD-160 (BouncyCastle) | 137B         |     667.7 ns |     1.71 ns |     1.60 ns |      96 B |
| ComputeHash | RIPEMD-160 | RIPEMD-160 (Managed)      | 137B         |     983.6 ns |     7.49 ns |     6.64 ns |      96 B |
|                                                      |              |              |             |             |           |
| ComputeHash | RIPEMD-160 | RIPEMD-160 (BouncyCastle) | 1KB          |   3,549.7 ns |     9.36 ns |     8.30 ns |      96 B |
| ComputeHash | RIPEMD-160 | RIPEMD-160 (Managed)      | 1KB          |   5,483.3 ns |    63.22 ns |    59.14 ns |      96 B |
|                                                      |              |              |             |             |           |
| ComputeHash | RIPEMD-160 | RIPEMD-160 (BouncyCastle) | 1025B        |   3,560.4 ns |     9.71 ns |     9.08 ns |      96 B |
| ComputeHash | RIPEMD-160 | RIPEMD-160 (Managed)      | 1025B        |   5,462.8 ns |    31.05 ns |    29.05 ns |      96 B |
|                                                      |              |              |             |             |           |
| ComputeHash | RIPEMD-160 | RIPEMD-160 (BouncyCastle) | 8KB          |  26,593.4 ns |    83.19 ns |    77.82 ns |      96 B |
| ComputeHash | RIPEMD-160 | RIPEMD-160 (Managed)      | 8KB          |  40,242.7 ns |   335.03 ns |   297.00 ns |      96 B |
|                                                      |              |              |             |             |           |
| ComputeHash | RIPEMD-160 | RIPEMD-160 (BouncyCastle) | 128KB        | 424,885.0 ns |   831.23 ns |   736.87 ns |      96 B |
| ComputeHash | RIPEMD-160 | RIPEMD-160 (Managed)      | 128KB        | 645,818.7 ns | 5,786.69 ns | 5,412.87 ns |      96 B |