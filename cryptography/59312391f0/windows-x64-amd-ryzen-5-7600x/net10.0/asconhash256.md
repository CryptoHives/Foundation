| Description                                                | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|----------------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| ComputeHash | Ascon-Hash256 | Ascon-Hash256 (BouncyCastle) | 128B         |     796.5 ns |     5.71 ns |     5.34 ns |     112 B |
| ComputeHash | Ascon-Hash256 | Ascon-Hash256 (Managed)      | 128B         |     804.6 ns |    15.50 ns |    15.92 ns |     112 B |
|                                                            |              |              |             |             |           |
| ComputeHash | Ascon-Hash256 | Ascon-Hash256 (Managed)      | 137B         |     818.6 ns |     7.03 ns |     6.58 ns |     112 B |
| ComputeHash | Ascon-Hash256 | Ascon-Hash256 (BouncyCastle) | 137B         |     834.4 ns |     9.92 ns |     9.28 ns |     112 B |
|                                                            |              |              |             |             |           |
| ComputeHash | Ascon-Hash256 | Ascon-Hash256 (Managed)      | 1KB          |   4,881.5 ns |    42.78 ns |    37.93 ns |     112 B |
| ComputeHash | Ascon-Hash256 | Ascon-Hash256 (BouncyCastle) | 1KB          |   4,983.0 ns |    21.41 ns |    17.88 ns |     112 B |
|                                                            |              |              |             |             |           |
| ComputeHash | Ascon-Hash256 | Ascon-Hash256 (Managed)      | 1025B        |   4,882.1 ns |    22.72 ns |    20.14 ns |     112 B |
| ComputeHash | Ascon-Hash256 | Ascon-Hash256 (BouncyCastle) | 1025B        |   4,994.5 ns |    31.34 ns |    29.32 ns |     112 B |
|                                                            |              |              |             |             |           |
| ComputeHash | Ascon-Hash256 | Ascon-Hash256 (Managed)      | 8KB          |  37,506.6 ns |   267.99 ns |   223.79 ns |     112 B |
| ComputeHash | Ascon-Hash256 | Ascon-Hash256 (BouncyCastle) | 8KB          |  38,580.9 ns |   268.88 ns |   251.52 ns |     112 B |
|                                                            |              |              |             |             |           |
| ComputeHash | Ascon-Hash256 | Ascon-Hash256 (Managed)      | 128KB        | 597,915.3 ns | 4,194.06 ns | 3,923.13 ns |     112 B |
| ComputeHash | Ascon-Hash256 | Ascon-Hash256 (BouncyCastle) | 128KB        | 613,417.1 ns | 2,995.21 ns | 2,801.72 ns |     112 B |