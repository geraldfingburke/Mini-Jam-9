using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public Text weekNumber;
	public Text semesterNumber;
	public Text gradesLetter;
	
	public Slider healthSlider;
	public Slider hapinessSlider;
	public Slider familySlider;

	public Text cashNumber;
	public Text billsNumber;

	public Text creditsEarnedText;
	public Text creditsRemainingText;

	public Text hoursNumber;
	public Text sleepNumber;
	public Text workNumber;
	public Text studyNumber;
	public Text familyNumber;
	public Text gameDevNumber;

	public float healthStat;
	public float hapinessStat;
	public float familyStat;
	
	public float cash;
	public float bills;

	public int week;
	public int semester;

	public double grades;

	public int creditsEarned;
	public int creditsRemaining;

	public int hours;
	public int sleep;
	public int work;
	public int study;
	public int family;
	public int gameDev;

	// Use this for initialization
	void Start () {
		healthStat = 10;
		hapinessStat = 10;
		familyStat = 10;

		cash = 0;
		bills = 450;
		
		week = 1;
		semester = 1;

		grades = 4.0;

		creditsEarned = 0;
		creditsRemaining = 60;

		hours = 24;
		sleep = 0;
		work = 0;
		study = 0;
		family = 0;
		gameDev = 0;
	}
	
	// Update is called once per frame
	void Update () {
		healthSlider.value = healthStat * 0.1f;
		hapinessSlider.value = hapinessStat * 0.1f;
		familySlider.value = familyStat * 0.1f;
		
		cashNumber.text = cash.ToString();
		billsNumber.text = bills.ToString();

		weekNumber.text = week.ToString();
		semesterNumber.text = semester.ToString();

		if (grades == 4) {
			gradesLetter.text = "A";
		} else if (grades < 4 && grades >= 3) {
			gradesLetter.text = "B";
		} else if (grades < 3 && grades >= 2) {
			gradesLetter.text = "C";
		} else if (grades < 2 && grades >= 1) {
			gradesLetter.text = "D";
		} else if (grades < 1) {
			gradesLetter.text = "F";
		}

		creditsEarnedText.text = creditsEarned.ToString();
		creditsRemainingText.text = creditsRemaining.ToString();

		hoursNumber.text = hours.ToString();
		sleepNumber.text = sleep.ToString();
		workNumber.text = work.ToString();
		studyNumber.text = study.ToString();
		familyNumber.text = family.ToString();
		gameDevNumber.text = gameDev.ToString();

		if (healthStat <= 0) {
			SceneManager.LoadScene("GO_Health");
		}
		if (hapinessStat <= 0) {
			SceneManager.LoadScene("GO_Hapiness");
		}
		if (familyStat <= 0) {
			SceneManager.LoadScene("GO_Family");
		}
		if (cash <= -100) {
			SceneManager.LoadScene("GO_Cash");
		}
		if (grades <= 1) {
			SceneManager.LoadScene("GO_Grades");
		}
		if (creditsRemaining <= 0) {
			SceneManager.LoadScene("GO_Win");
		}
	}

	public void Add (string stat) {
		switch (stat) {
			case "Sleep":
				if (hours > 0) {
					Debug.Log("clicked");
					sleep++;
					hours--;
				}
			break;
			case "Work":
				if (hours > 0) {
					work++;
					hours--;
				}
			break;
			case "Study":
				if (hours > 0 && study < 8) {
					study++;
					hours--;
				}
			break;
			case "Family":
				if (hours > 0) {
					family++;
					hours--;
				}
			break;
			case "Game Dev":
				if (hours > 0) {
					gameDev++;
					hours--;
				}
			break;
		}

	}

	public void Subtract (string stat) {
		switch (stat) {
			case "Sleep":
				if (sleep > 0) {
					sleep--;
					hours++;
				}
			break;
			case "Work":
				if (work > 0) {
					work--;
					hours++;
				}
			break;
			case "Study":
				if (study > 0) {
					study--;
					hours++;
				}
			break;
			case "Family":
				if (family > 0) {
					family--;
					hours++;
				}
			break;
			case "Game Dev":
				if (gameDev > 0) {
					gameDev--;
					hours++;
				}
			break;
		}
		
		
	}
	public void PlayWeek() {
		if (hours == 0) {
			if (week == 15) {
				week = 1;
				semester ++;
				if (grades >= 1) {
					creditsEarned += 15;
					creditsRemaining -=15;
				}
				grades = 4;
			} else if (week < 15) {
				week++;
				grades = grades / week;
			}

			if (sleep < 3) {
				healthStat -= 2;
			} else if (sleep < 6 && sleep >= 3) {
				healthStat--; 
			} else if (sleep > 6 && sleep <= 9) {
				healthStat++;
			} else if (sleep > 9) {
				healthStat += 2;
			}

			cash += (work * 7) * 10;

			cash -= bills;

			switch (study) {
				case 0 :
					grades += 0;
					break;
				case 1 :
					grades += 0.5;
					break;
				case 2 :
					grades += 1;
					break;
				case 3 :
					grades += 1.5;
					break;
				case 4 :
					grades += 2;
					break;
				case 5 :
					grades += 2.5;
					break;
				case 6 :
					grades += 3;
					break;
				case 7 :
					grades += 3.5;
					break;
				case 8 :
					grades += 4;
					break;
			}

			if (family < 3) {
				familyStat -= 2;
			} else if (family < 4 && family >= 3) {
				familyStat--; 
			} else if (family > 5 && family <= 6) {
				familyStat++;
			} else if (family > 7) {
				familyStat += 2;
			}

			if (gameDev < 3) {
				hapinessStat -= 2;
			} else if (gameDev < 4 && gameDev >= 3) {
			hapinessStat--; 
			} else if (gameDev > 5 && gameDev <= 6) {
				hapinessStat++;
			} else if (gameDev > 7) {
				hapinessStat += 2;
			}
		}
	}
}
