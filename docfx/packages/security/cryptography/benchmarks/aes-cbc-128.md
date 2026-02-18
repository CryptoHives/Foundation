| Description                          | TestDataSize | Mean          | Error        | StdDev       | Allocated |
|------------------------------------- |------------- |--------------:|-------------:|-------------:|----------:|
| Decrypt · AES-128-CBC (AES-NI)       | 128B         |      25.89 ns |     0.172 ns |     0.161 ns |         - |
| Decrypt · AES-128-CBC (OS)           | 128B         |     242.80 ns |     1.727 ns |     1.615 ns |     128 B |
| Decrypt · AES-128-CBC (Managed)      | 128B         |     439.28 ns |     3.110 ns |     2.909 ns |         - |
| Decrypt · AES-128-CBC (BouncyCastle) | 128B         |     688.10 ns |     2.879 ns |     2.552 ns |     832 B |
|                                      |              |               |              |              |           |
| Encrypt · AES-128-CBC (AES-NI)       | 128B         |     160.36 ns |     3.163 ns |     3.384 ns |         - |
| Encrypt · AES-128-CBC (OS)           | 128B         |     273.42 ns |     1.277 ns |     1.194 ns |     128 B |
| Encrypt · AES-128-CBC (Managed)      | 128B         |     401.26 ns |     3.159 ns |     2.955 ns |         - |
| Encrypt · AES-128-CBC (BouncyCastle) | 128B         |     628.08 ns |     4.993 ns |     4.426 ns |     832 B |
|                                      |              |               |              |              |           |
| Decrypt · AES-128-CBC (AES-NI)       | 1KB          |      90.35 ns |     0.783 ns |     0.732 ns |         - |
| Decrypt · AES-128-CBC (OS)           | 1KB          |     293.39 ns |     1.786 ns |     1.671 ns |     128 B |
| Decrypt · AES-128-CBC (Managed)      | 1KB          |   3,119.15 ns |    31.165 ns |    29.151 ns |         - |
| Decrypt · AES-128-CBC (BouncyCastle) | 1KB          |   3,861.75 ns |    38.710 ns |    36.209 ns |     832 B |
|                                      |              |               |              |              |           |
| Encrypt · AES-128-CBC (OS)           | 1KB          |     695.62 ns |     2.564 ns |     2.399 ns |     128 B |
| Encrypt · AES-128-CBC (AES-NI)       | 1KB          |   1,241.05 ns |     2.890 ns |     2.413 ns |         - |
| Encrypt · AES-128-CBC (Managed)      | 1KB          |   3,142.42 ns |    38.946 ns |    36.430 ns |         - |
| Encrypt · AES-128-CBC (BouncyCastle) | 1KB          |   3,730.91 ns |    27.209 ns |    24.120 ns |     832 B |
|                                      |              |               |              |              |           |
| Decrypt · AES-128-CBC (AES-NI)       | 8KB          |     584.95 ns |     1.830 ns |     1.528 ns |         - |
| Decrypt · AES-128-CBC (OS)           | 8KB          |     739.71 ns |     3.150 ns |     2.631 ns |     128 B |
| Decrypt · AES-128-CBC (Managed)      | 8KB          |  24,553.17 ns |   156.238 ns |   138.501 ns |         - |
| Decrypt · AES-128-CBC (BouncyCastle) | 8KB          |  29,063.09 ns |   158.005 ns |   140.067 ns |     832 B |
|                                      |              |               |              |              |           |
| Encrypt · AES-128-CBC (OS)           | 8KB          |   4,261.86 ns |    30.311 ns |    23.664 ns |     128 B |
| Encrypt · AES-128-CBC (AES-NI)       | 8KB          |   9,933.77 ns |    87.157 ns |    81.527 ns |         - |
| Encrypt · AES-128-CBC (Managed)      | 8KB          |  25,011.18 ns |   146.816 ns |   137.332 ns |         - |
| Encrypt · AES-128-CBC (BouncyCastle) | 8KB          |  28,404.16 ns |   154.816 ns |   144.815 ns |     832 B |
|                                      |              |               |              |              |           |
| Decrypt · AES-128-CBC (OS)           | 128KB        |   8,156.45 ns |    41.029 ns |    38.379 ns |     128 B |
| Decrypt · AES-128-CBC (AES-NI)       | 128KB        |   8,958.63 ns |    61.209 ns |    57.255 ns |         - |
| Decrypt · AES-128-CBC (Managed)      | 128KB        | 393,462.28 ns | 2,298.359 ns | 2,037.436 ns |         - |
| Decrypt · AES-128-CBC (BouncyCastle) | 128KB        | 461,121.00 ns | 3,324.674 ns | 3,109.902 ns |     832 B |
|                                      |              |               |              |              |           |
| Encrypt · AES-128-CBC (OS)           | 128KB        |  65,921.95 ns |   463.900 ns |   433.933 ns |     128 B |
| Encrypt · AES-128-CBC (AES-NI)       | 128KB        | 160,266.19 ns |   414.950 ns |   323.966 ns |         - |
| Encrypt · AES-128-CBC (Managed)      | 128KB        | 410,846.74 ns | 6,429.868 ns | 8,360.645 ns |         - |
| Encrypt · AES-128-CBC (BouncyCastle) | 128KB        | 461,790.46 ns | 8,723.703 ns | 8,160.157 ns |     832 B |