| Description                                                | TestDataSize | Mean         | Error        | StdDev       | Allocated |
|----------------------------------------------------------- |------------- |-------------:|-------------:|-------------:|----------:|
| ComputeHash · Ascon-Hash256 · Ascon-Hash256 (Managed)      | 128B         |     609.3 ns |      8.12 ns |      7.20 ns |     112 B |
| ComputeHash · Ascon-Hash256 · Ascon-Hash256 (BouncyCastle) | 128B         |     793.7 ns |      8.93 ns |      8.36 ns |     112 B |
|                                                            |              |              |              |              |           |
| ComputeHash · Ascon-Hash256 · Ascon-Hash256 (Managed)      | 137B         |     635.2 ns |      3.99 ns |      3.54 ns |     112 B |
| ComputeHash · Ascon-Hash256 · Ascon-Hash256 (BouncyCastle) | 137B         |     836.0 ns |      7.91 ns |      7.01 ns |     112 B |
|                                                            |              |              |              |              |           |
| ComputeHash · Ascon-Hash256 · Ascon-Hash256 (Managed)      | 1KB          |   3,786.9 ns |     21.69 ns |     18.11 ns |     112 B |
| ComputeHash · Ascon-Hash256 · Ascon-Hash256 (BouncyCastle) | 1KB          |   4,990.5 ns |     38.87 ns |     36.36 ns |     112 B |
|                                                            |              |              |              |              |           |
| ComputeHash · Ascon-Hash256 · Ascon-Hash256 (Managed)      | 1025B        |   3,796.0 ns |     43.22 ns |     38.31 ns |     112 B |
| ComputeHash · Ascon-Hash256 · Ascon-Hash256 (BouncyCastle) | 1025B        |   4,983.3 ns |     31.69 ns |     29.64 ns |     112 B |
|                                                            |              |              |              |              |           |
| ComputeHash · Ascon-Hash256 · Ascon-Hash256 (Managed)      | 8KB          |  29,196.5 ns |    214.67 ns |    200.80 ns |     112 B |
| ComputeHash · Ascon-Hash256 · Ascon-Hash256 (BouncyCastle) | 8KB          |  38,585.1 ns |    313.93 ns |    293.65 ns |     112 B |
|                                                            |              |              |              |              |           |
| ComputeHash · Ascon-Hash256 · Ascon-Hash256 (Managed)      | 128KB        | 464,318.3 ns |  3,234.61 ns |  3,025.66 ns |     112 B |
| ComputeHash · Ascon-Hash256 · Ascon-Hash256 (BouncyCastle) | 128KB        | 627,055.7 ns | 11,566.85 ns | 11,360.19 ns |     112 B |