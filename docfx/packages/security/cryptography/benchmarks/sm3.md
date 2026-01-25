| Description                            | TestDataSize | Mean         | Error        | StdDev       | Allocated |
|--------------------------------------- |------------- |-------------:|-------------:|-------------:|----------:|
| ComputeHash | SM3 | SM3 (BouncyCastle) | 128B         |     822.0 ns |      5.41 ns |      4.52 ns |     112 B |
| ComputeHash | SM3 | SM3 (Managed)      | 128B         |     944.8 ns |      2.97 ns |      2.64 ns |     112 B |
|                                        |              |              |              |              |           |
| ComputeHash | SM3 | SM3 (BouncyCastle) | 137B         |     810.6 ns |      3.53 ns |      3.30 ns |     112 B |
| ComputeHash | SM3 | SM3 (Managed)      | 137B         |     949.1 ns |      3.53 ns |      2.94 ns |     112 B |
|                                        |              |              |              |              |           |
| ComputeHash | SM3 | SM3 (BouncyCastle) | 1KB          |   4,460.1 ns |     28.36 ns |     23.68 ns |     112 B |
| ComputeHash | SM3 | SM3 (Managed)      | 1KB          |   5,235.7 ns |     29.36 ns |     26.03 ns |     112 B |
|                                        |              |              |              |              |           |
| ComputeHash | SM3 | SM3 (BouncyCastle) | 1025B        |   4,465.8 ns |     35.12 ns |     27.42 ns |     112 B |
| ComputeHash | SM3 | SM3 (Managed)      | 1025B        |   5,191.9 ns |     15.74 ns |     13.14 ns |     112 B |
|                                        |              |              |              |              |           |
| ComputeHash | SM3 | SM3 (BouncyCastle) | 8KB          |  33,064.3 ns |    197.72 ns |    184.95 ns |     112 B |
| ComputeHash | SM3 | SM3 (Managed)      | 8KB          |  39,026.0 ns |    175.15 ns |    155.27 ns |     112 B |
|                                        |              |              |              |              |           |
| ComputeHash | SM3 | SM3 (BouncyCastle) | 128KB        | 535,392.3 ns | 10,541.30 ns | 11,716.63 ns |     112 B |
| ComputeHash | SM3 | SM3 (Managed)      | 128KB        | 624,985.2 ns |  6,128.39 ns |  5,732.50 ns |     112 B |