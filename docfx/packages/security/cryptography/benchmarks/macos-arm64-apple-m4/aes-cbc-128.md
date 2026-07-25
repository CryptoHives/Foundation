| Description                                 | TestDataSize | Mean          | Error      | StdDev     | Allocated |
|-------------------------------------------- |------------- |--------------:|-----------:|-----------:|----------:|
| Decrypt · AES-128-CBC (CryptoHives-ARM-AES) | 128B         |      23.19 ns |   0.007 ns |   0.007 ns |         - |
| Decrypt · AES-128-CBC (OS)                  | 128B         |     192.01 ns |   0.889 ns |   0.788 ns |      72 B |
| Decrypt · AES-128-CBC (CryptoHives-Scalar)  | 128B         |     386.49 ns |   0.065 ns |   0.057 ns |         - |
| Decrypt · AES-128-CBC (BouncyCastle)        | 128B         |     617.72 ns |   0.471 ns |   0.441 ns |     832 B |
|                                             |              |               |            |            |           |
| Encrypt · AES-128-CBC (CryptoHives-ARM-AES) | 128B         |      41.23 ns |   0.158 ns |   0.148 ns |         - |
| Encrypt · AES-128-CBC (OS)                  | 128B         |     201.05 ns |   1.076 ns |   0.840 ns |      72 B |
| Encrypt · AES-128-CBC (CryptoHives-Scalar)  | 128B         |     437.71 ns |   1.098 ns |   0.917 ns |         - |
| Encrypt · AES-128-CBC (BouncyCastle)        | 128B         |     575.40 ns |   0.335 ns |   0.314 ns |     832 B |
|                                             |              |               |            |            |           |
| Decrypt · AES-128-CBC (CryptoHives-ARM-AES) | 1KB          |      90.87 ns |   0.150 ns |   0.141 ns |         - |
| Decrypt · AES-128-CBC (OS)                  | 1KB          |     234.00 ns |   0.502 ns |   0.470 ns |      72 B |
| Decrypt · AES-128-CBC (CryptoHives-Scalar)  | 1KB          |   2,704.25 ns |   0.871 ns |   0.772 ns |         - |
| Decrypt · AES-128-CBC (BouncyCastle)        | 1KB          |   3,382.69 ns |   2.480 ns |   2.071 ns |     832 B |
|                                             |              |               |            |            |           |
| Encrypt · AES-128-CBC (CryptoHives-ARM-AES) | 1KB          |     380.61 ns |   2.884 ns |   2.556 ns |         - |
| Encrypt · AES-128-CBC (OS)                  | 1KB          |     564.03 ns |   3.757 ns |   3.515 ns |      72 B |
| Encrypt · AES-128-CBC (CryptoHives-Scalar)  | 1KB          |   3,138.87 ns |   5.853 ns |   5.188 ns |         - |
| Encrypt · AES-128-CBC (BouncyCastle)        | 1KB          |   3,266.56 ns |   5.467 ns |   4.565 ns |     832 B |
|                                             |              |               |            |            |           |
| Decrypt · AES-128-CBC (OS)                  | 8KB          |     581.36 ns |   2.844 ns |   2.660 ns |      72 B |
| Decrypt · AES-128-CBC (CryptoHives-ARM-AES) | 8KB          |     640.09 ns |   1.202 ns |   1.065 ns |         - |
| Decrypt · AES-128-CBC (CryptoHives-Scalar)  | 8KB          |  21,343.26 ns |  21.504 ns |  19.063 ns |         - |
| Decrypt · AES-128-CBC (BouncyCastle)        | 8KB          |  25,300.61 ns |  60.646 ns |  56.728 ns |     832 B |
|                                             |              |               |            |            |           |
| Encrypt · AES-128-CBC (OS)                  | 8KB          |   3,273.80 ns |   9.650 ns |   8.555 ns |      72 B |
| Encrypt · AES-128-CBC (CryptoHives-ARM-AES) | 8KB          |   3,450.27 ns |  32.636 ns |  30.528 ns |         - |
| Encrypt · AES-128-CBC (BouncyCastle)        | 8KB          |  24,689.08 ns |   3.414 ns |   2.665 ns |     832 B |
| Encrypt · AES-128-CBC (CryptoHives-Scalar)  | 8KB          |  24,724.25 ns |  86.110 ns |  71.906 ns |         - |
|                                             |              |               |            |            |           |
| Decrypt · AES-128-CBC (OS)                  | 128KB        |   6,629.29 ns |  18.800 ns |  17.586 ns |      72 B |
| Decrypt · AES-128-CBC (CryptoHives-ARM-AES) | 128KB        |  10,038.25 ns |   8.793 ns |   8.225 ns |         - |
| Decrypt · AES-128-CBC (CryptoHives-Scalar)  | 128KB        | 342,411.79 ns |  69.569 ns |  65.075 ns |         - |
| Decrypt · AES-128-CBC (BouncyCastle)        | 128KB        | 403,306.84 ns | 776.467 ns | 726.308 ns |     832 B |
|                                             |              |               |            |            |           |
| Encrypt · AES-128-CBC (OS)                  | 128KB        |  50,702.29 ns | 148.293 ns | 138.713 ns |      72 B |
| Encrypt · AES-128-CBC (CryptoHives-ARM-AES) | 128KB        |  55,703.13 ns |  11.048 ns |   9.794 ns |         - |
| Encrypt · AES-128-CBC (CryptoHives-Scalar)  | 128KB        | 393,947.83 ns | 233.883 ns | 207.332 ns |         - |
| Encrypt · AES-128-CBC (BouncyCastle)        | 128KB        | 395,797.91 ns |  64.196 ns |  60.049 ns |     832 B |