| Description                          | TestDataSize | Mean          | Error        | StdDev       | Allocated |
|------------------------------------- |------------- |--------------:|-------------:|-------------:|----------:|
| Decrypt · AES-128-CBC (AES-NI)       | 128B         |      44.10 ns |     0.704 ns |     0.659 ns |         - |
| Decrypt · AES-128-CBC (OS)           | 128B         |     249.41 ns |     4.923 ns |     5.267 ns |     128 B |
| Decrypt · AES-128-CBC (Managed)      | 128B         |     459.12 ns |     5.508 ns |     4.883 ns |         - |
| Decrypt · AES-128-CBC (BouncyCastle) | 128B         |     719.11 ns |    11.461 ns |    10.721 ns |     832 B |
|                                      |              |               |              |              |           |
| Encrypt · AES-128-CBC (AES-NI)       | 128B         |     184.99 ns |     3.682 ns |     4.092 ns |         - |
| Encrypt · AES-128-CBC (OS)           | 128B         |     288.63 ns |     5.632 ns |     5.531 ns |     128 B |
| Encrypt · AES-128-CBC (Managed)      | 128B         |     466.20 ns |     4.816 ns |     4.505 ns |         - |
| Encrypt · AES-128-CBC (BouncyCastle) | 128B         |     649.70 ns |    12.379 ns |    12.713 ns |     832 B |
|                                      |              |               |              |              |           |
| Decrypt · AES-128-CBC (AES-NI)       | 1KB          |     216.81 ns |     2.639 ns |     2.468 ns |         - |
| Decrypt · AES-128-CBC (OS)           | 1KB          |     301.84 ns |     5.993 ns |     5.886 ns |     128 B |
| Decrypt · AES-128-CBC (Managed)      | 1KB          |   3,220.48 ns |    35.684 ns |    33.379 ns |         - |
| Decrypt · AES-128-CBC (BouncyCastle) | 1KB          |   3,980.14 ns |    54.817 ns |    51.276 ns |     832 B |
|                                      |              |               |              |              |           |
| Encrypt · AES-128-CBC (OS)           | 1KB          |     714.63 ns |     7.584 ns |     7.094 ns |     128 B |
| Encrypt · AES-128-CBC (AES-NI)       | 1KB          |   1,197.31 ns |     9.733 ns |     9.105 ns |         - |
| Encrypt · AES-128-CBC (Managed)      | 1KB          |   3,267.34 ns |    49.117 ns |    43.541 ns |         - |
| Encrypt · AES-128-CBC (BouncyCastle) | 1KB          |   3,835.67 ns |    34.186 ns |    30.305 ns |     832 B |
|                                      |              |               |              |              |           |
| Decrypt · AES-128-CBC (OS)           | 8KB          |     763.33 ns |     4.377 ns |     3.655 ns |     128 B |
| Decrypt · AES-128-CBC (AES-NI)       | 8KB          |   1,574.64 ns |    14.412 ns |    13.481 ns |         - |
| Decrypt · AES-128-CBC (Managed)      | 8KB          |  25,255.76 ns |   174.010 ns |   162.769 ns |         - |
| Decrypt · AES-128-CBC (BouncyCastle) | 8KB          |  29,994.72 ns |   209.370 ns |   185.601 ns |     832 B |
|                                      |              |               |              |              |           |
| Encrypt · AES-128-CBC (OS)           | 8KB          |   4,128.28 ns |    35.744 ns |    33.435 ns |     128 B |
| Encrypt · AES-128-CBC (AES-NI)       | 8KB          |   9,335.69 ns |   100.379 ns |    93.895 ns |         - |
| Encrypt · AES-128-CBC (Managed)      | 8KB          |  25,437.86 ns |   321.076 ns |   284.625 ns |         - |
| Encrypt · AES-128-CBC (BouncyCastle) | 8KB          |  29,313.08 ns |   172.208 ns |   161.084 ns |     832 B |
|                                      |              |               |              |              |           |
| Decrypt · AES-128-CBC (OS)           | 128KB        |   8,411.33 ns |   109.823 ns |   102.729 ns |     128 B |
| Decrypt · AES-128-CBC (AES-NI)       | 128KB        |  25,147.51 ns |   236.561 ns |   221.279 ns |         - |
| Decrypt · AES-128-CBC (Managed)      | 128KB        | 403,154.61 ns | 7,645.144 ns | 6,777.221 ns |         - |
| Decrypt · AES-128-CBC (BouncyCastle) | 128KB        | 475,362.74 ns | 3,881.115 ns | 3,440.507 ns |     832 B |
|                                      |              |               |              |              |           |
| Encrypt · AES-128-CBC (OS)           | 128KB        |  65,522.78 ns |   401.916 ns |   356.288 ns |     128 B |
| Encrypt · AES-128-CBC (AES-NI)       | 128KB        | 150,644.67 ns | 1,605.531 ns | 1,423.262 ns |         - |
| Encrypt · AES-128-CBC (Managed)      | 128KB        | 407,184.16 ns | 5,165.444 ns | 4,831.760 ns |         - |
| Encrypt · AES-128-CBC (BouncyCastle) | 128KB        | 467,072.69 ns | 7,661.957 ns | 7,167.000 ns |     832 B |