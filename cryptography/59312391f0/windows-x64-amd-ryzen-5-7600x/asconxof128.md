| Description                                              | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|--------------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| ComputeHash | Ascon-XOF128 | Ascon-XOF128 (Managed)      | 128B         |     778.1 ns |     4.39 ns |     3.89 ns |     112 B |
| ComputeHash | Ascon-XOF128 | Ascon-XOF128 (BouncyCastle) | 128B         |     792.7 ns |     8.04 ns |     7.52 ns |     112 B |
|                                                          |              |              |             |             |           |
| ComputeHash | Ascon-XOF128 | Ascon-XOF128 (Managed)      | 137B         |     814.6 ns |     9.17 ns |     8.58 ns |     112 B |
| ComputeHash | Ascon-XOF128 | Ascon-XOF128 (BouncyCastle) | 137B         |     828.6 ns |     5.03 ns |     4.70 ns |     112 B |
|                                                          |              |              |             |             |           |
| ComputeHash | Ascon-XOF128 | Ascon-XOF128 (Managed)      | 1KB          |   4,868.9 ns |    43.59 ns |    40.77 ns |     112 B |
| ComputeHash | Ascon-XOF128 | Ascon-XOF128 (BouncyCastle) | 1KB          |   4,952.8 ns |    38.23 ns |    35.76 ns |     112 B |
|                                                          |              |              |             |             |           |
| ComputeHash | Ascon-XOF128 | Ascon-XOF128 (Managed)      | 1025B        |   4,858.2 ns |    24.17 ns |    21.43 ns |     112 B |
| ComputeHash | Ascon-XOF128 | Ascon-XOF128 (BouncyCastle) | 1025B        |   4,933.8 ns |    24.36 ns |    21.59 ns |     112 B |
|                                                          |              |              |             |             |           |
| ComputeHash | Ascon-XOF128 | Ascon-XOF128 (Managed)      | 8KB          |  37,574.3 ns |   277.73 ns |   246.20 ns |     112 B |
| ComputeHash | Ascon-XOF128 | Ascon-XOF128 (BouncyCastle) | 8KB          |  38,216.5 ns |   303.26 ns |   283.67 ns |     112 B |
|                                                          |              |              |             |             |           |
| ComputeHash | Ascon-XOF128 | Ascon-XOF128 (Managed)      | 128KB        | 598,430.4 ns | 5,502.42 ns | 5,146.97 ns |     112 B |
| ComputeHash | Ascon-XOF128 | Ascon-XOF128 (BouncyCastle) | 128KB        | 609,433.8 ns | 2,892.44 ns | 2,564.08 ns |     112 B |